using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xaml;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for New_User.xaml
    /// </summary>
    public partial class New_User : Window
    {
        MainWindow prev_window;
        DispatcherTimer timer;
        int tickcounter = 0;
        List<int> thissesstimes = new List<int>();
        List<List<int>> interkey_times;
        int training_sess = 0;
        int max_tr_sess = 3;
        string temp_pass;
        bool isModify = false;

        public static New_User this_New_User;
        string Masterkey = "admin";

        public New_User()
        {
            InitializeComponent();
            this_New_User = this;
            prev_window = WpfApplication1.MainWindow.thiswindow;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;

            Attempt_no.Content = "Training Session: " + training_sess.ToString();
            if (training_sess < max_tr_sess)
            {
                Add_New_User.IsEnabled = false;
            }
            else
                Add_New_User.IsEnabled = true;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            tickcounter += 1;
        }

        private void Add_New_User_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameinput.Text) && !string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                if (!prev_window.credentials.ContainsKey(usernameinput.Text))
                {
                    prev_window.credentials.Add(usernameinput.Text, passwordBox.Password);
                    XamlServices.Save(prev_window.db_filename, prev_window.credentials);
                    prev_window.interkey_time_data.Add(usernameinput.Text, interkey_times);
                    XamlServices.Save(prev_window.db_interkey_times, prev_window.interkey_time_data);
                    MessageBox.Show("New Account Added.");
                    training_sess = 0;
                    Attempt_no.Content = "Training Session: " + training_sess.ToString();
                    Add_New_User.IsEnabled = false;
                    usernameinput.Clear();
                    passwordBox.Clear();

                }
                else if (isModify == true)
                {
                    prev_window.credentials[usernameinput.Text] = passwordBox.Password;
                    prev_window.interkey_time_data[usernameinput.Text] = interkey_times;
                    XamlServices.Save(prev_window.db_filename, prev_window.credentials);
                    XamlServices.Save(prev_window.db_interkey_times, prev_window.interkey_time_data);
                    MessageBox.Show("Account Modified.");
                    training_sess = 0;
                    Attempt_no.Content = "Training Session: " + training_sess.ToString();
                    Add_New_User.IsEnabled = false;
                    usernameinput.Clear();
                    passwordBox.Clear();
                }
            }
            else
                MessageBox.Show("One or more fields are empty.");

        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            thissesstimes.Add(tickcounter);
            timer.Stop();
            tickcounter = 0;
            timer.Start();
        }

        private void Ret_to_Login_Click(object sender, RoutedEventArgs e)
        {
            prev_window.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prev_window.Show();
        }

        private void Attempt_no_Click(object sender, RoutedEventArgs e)
        {
            if (!prev_window.credentials.ContainsKey(usernameinput.Text) || isModify == true)
            {
                if (training_sess < max_tr_sess)
                {
                    if (!string.IsNullOrWhiteSpace(usernameinput.Text) && !string.IsNullOrWhiteSpace(passwordBox.Password))
                    {
                        Add_New_User.IsEnabled = false;

                        if (training_sess == 0)
                        {
                            temp_pass = passwordBox.Password;
                            interkey_times = new List<List<int>>();
                            interkey_times.Add(thissesstimes);
                            count.Content = interkey_times.Count;
                            thissesstimes = new List<int>();
                            timer.Stop();
                            tickcounter = 0;
                            training_sess++;
                            Attempt_no.Content = "Training Session: " + training_sess.ToString();
                            passwordBox.Clear();
                            passwordBox.Focus();
                        }

                        else if (training_sess > 0)
                        {
                            if (String.Equals(passwordBox.Password, temp_pass))
                            {
                                interkey_times.Add(thissesstimes);
                                count.Content = interkey_times.Count;
                                thissesstimes = new List<int>();
                                timer.Stop();
                                tickcounter = 0;
                                training_sess++;
                                Attempt_no.Content = "Training Session: " + training_sess.ToString();
                                if (training_sess != max_tr_sess)
                                {
                                    passwordBox.Clear();
                                    passwordBox.Focus();
                                }
                            }
                            else
                                MessageBox.Show("Passwords don't match.");
                        }


                    }
                    else
                        MessageBox.Show("One or more fields empty.");
                }
            }
            else if (isModify == false)
            {
                if (MessageBox.Show("User Exists. Modify User Credentials?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    isModify = true;
            }

            //    if (MessageBox.Show("User Exists. Modify User Credentials?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes || isModify == true)
            //{
            //    //Admin_Modify admin_mod_win = new Admin_Modify();
            //    //admin_mod_win.Show();
            //    //admin_mod_win.Owner = this_New_User;
            //    //this.Hide();

            //}

            if (training_sess == max_tr_sess)
                Add_New_User.IsEnabled = true;
             
        }
    }
}
