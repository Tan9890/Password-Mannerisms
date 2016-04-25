using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Admin_Modify.xaml
    /// </summary>
    public partial class Admin_Modify : Window
    {
        MainWindow prev_window;
        public Admin_Modify()
        {
            InitializeComponent();
            prev_window = WpfApplication1.MainWindow.thiswindow;
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prev_window.Show();
        }

    }
}
