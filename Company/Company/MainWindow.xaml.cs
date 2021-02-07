using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 0;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += new EventHandler(timerTick);           
            timer.Start();
        }

        private void timerTick (object sender, EventArgs e)
        {
            x++;
            if(x == 8)
            {
                timer.Stop();
                RegAuth reg = new RegAuth();
                reg.Show();
                this.Close();
                
            }       
        }
    }
}
