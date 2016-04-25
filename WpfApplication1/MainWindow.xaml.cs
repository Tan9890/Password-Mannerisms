using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xaml;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pass = "qwerty123";
        string user = "tnp";

        public string db_filename = "database.xaml";
        public string db_interkey_times = "db_interkey_times.xaml";

        public double similarity_score = 0.20;
        public Dictionary<string, string> credentials;
        public Dictionary<string, List<List<int>>> interkey_time_data;

        DispatcherTimer timer;
        int tickcounter = 0;

        List<int> interkey = new List<int> { 0, 8, 70, 3, 69, 3, 76, 4, 10 };

        List<int> thissesstimes = new List<int>();
        public static MainWindow thiswindow;

        public MainWindow()
        {
            InitializeComponent();
            thiswindow = this;
            pass_plaintxt.Visibility = Visibility.Hidden;
            credentials = new Dictionary<string, string>();
            if (File.Exists(db_filename))
            {
                credentials = (Dictionary<string, string>)XamlServices.Load(db_filename);
            }
            else
                MessageBox.Show("Database does not exist");


            interkey_time_data = new Dictionary<string, List<List<int>>>();
            if (File.Exists(db_interkey_times))
                interkey_time_data = (Dictionary<string, List<List<int>>>)XamlServices.Load(db_interkey_times);
            else
                MessageBox.Show("Interkey Time database dows not exist.");

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            tickcounter += 1;
            //Timer_Display.Content = tickcounter;
        }

        private void Loginbutton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            tickcounter = 0;

            if (!string.IsNullOrWhiteSpace(usernameinput.Text) && !string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                if (credentials.ContainsKey(usernameinput.Text))
                {
                    if (String.Equals(passwordBox.Password, credentials[usernameinput.Text]))
                    {
                        List<List<int>> interkey_times = interkey_time_data[usernameinput.Text];

                        List<double> D = new List<double>();
                        Score.Items.Add("Scores:");
                        for (int i = 0; i < interkey_times.Count; i++)
                        {
                            double dscore = similaritychk(interkey_times[i], thissesstimes);
                            D.Add(dscore);
                            Score.Items.Add(dscore);
                        }

                        List<double> D_best = D.FindAll(Best_Similarity);
                        if (D_best.Count >= 2)
                        {
                            Show_data(interkey_times, thissesstimes);
                            MessageBox.Show("Login Successful.");                            
                        }
                        else
                        {
                            Show_data(interkey_times, thissesstimes);
                            MessageBox.Show("Login Info correct, Mannerism Mismatch.");
                            Clear_All();
                        }
                    }
                    else
                        MessageBox.Show("Incorrect Password!");
                        Clear_All();
                }
                else
                    MessageBox.Show("Account does not exist.");
            }
            else
                MessageBox.Show("Enter valid Login Information");
        }

        private bool Best_Similarity(double val)
        {
            if (val < similarity_score)
                return true;
            else
                return false;
        }

        private double similaritychk(List<int> interkey, List<int> thissessiontimes)
        {
            List<double> interkey_norm = normailize(interkey);
            List<double> thissessnorm = normailize(thissessiontimes);

            double D = 0;
            for (int i = 0; i < interkey_norm.Count; i++)
            {
                D += Math.Pow((interkey_norm[i] - thissessnorm[i]), 2);
            }
            return Math.Sqrt(D);
        }

        private List<double> normailize(List<int> vec)
        {
            double D = 0;
            for (int i = 1; i < vec.Count; i++)
            {
                D += Math.Pow((double)vec[i], 2);
            }
            D = Math.Sqrt(D);
            List<double> normalized_vec = new List<double>();
            for (int i = 0; i < vec.Count - 1; i++)
            {
                normalized_vec.Add(vec[i + 1] / D);
            }
            return normalized_vec;
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            thissesstimes.Add(tickcounter);
            timer.Stop();
            tickcounter = 0;
            timer.Start();
        }

        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            Clear_All();
            Score.Items.Clear();
            pv.Model = new PlotModel();
        }

        private void Clear_All()
        {
            thissesstimes = new List<int>();
            usernameinput.Clear();
            passwordBox.Clear();
            timer.Stop();
            tickcounter = 0;
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            New_User new_user_win = new New_User();
            new_user_win.Show();
            new_user_win.Owner = thiswindow;
            this.Hide();
        }

        private void Show_data(List<List<int>> ik_times, List<int> thissessiontimes)
        {
            PlotModel pm = new PlotModel { Title = "Pattern Plot", Subtitle = "Cross: DB Patterns, Circle: Current Pattern" };
            pm.Axes.Add(new LinearAxis { Key = "xAxis", Position = AxisPosition.Bottom});
            pm.Axes.Add(new LinearAxis { Key = "yAxis", Position = AxisPosition.Left, Title = "Interkey Time" });


            for (int i = 0; i < ik_times.Count; i++)
            {
                LineSeries l_ser = new LineSeries { Title = "Pattern: " + (i + 1).ToString(), MarkerType = MarkerType.Diamond, MarkerSize = 5, YAxisKey = "yAxis" };
                for (int j = 0; j < ik_times[i].Count; j++)
                {
                    l_ser.Points.Add(new DataPoint(j + 1, ik_times[i][j]));
                }
               pm.Series.Add(l_ser);
            }

            LineSeries curr_ser = new LineSeries { Title = "Current Pattern", MarkerType = MarkerType.Circle, MarkerSize = 5, YAxisKey = "yAxis" };
            for (int i = 0; i < thissessiontimes.Count; i++)
            {
                curr_ser.Points.Add(new DataPoint(i+1, thissessiontimes[i]));
            }
           pm.Series.Add(curr_ser);
            pv.Model = pm;
        }

        private void usernameinput_GotFocus(object sender, RoutedEventArgs e)
        {
            pv.Model = new PlotModel();
            Score.Items.Clear();
            pass_plaintxt.Clear();
            showpass.IsChecked = false;
        }

        private void showpass_Checked(object sender, RoutedEventArgs e)
        {
                pass_plaintxt.Text = passwordBox.Password;
                pass_plaintxt.Visibility = Visibility.Visible;
        }

        private void showpass_Unchecked(object sender, RoutedEventArgs e)
        {
            pass_plaintxt.Clear();
            pass_plaintxt.Visibility = Visibility.Hidden;
        }
    }
}
