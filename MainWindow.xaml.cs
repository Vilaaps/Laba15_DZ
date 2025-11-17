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
using System.Windows.Threading;

namespace DZ
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private TimeSpan stillTime;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            stillTime = stillTime.Subtract(TimeSpan.FromSeconds(1));
            TimeText.Text = $"{stillTime:mm\\:ss}";

            if (stillTime.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло!");
                initialValue();
            }
        }
        private void start_click(object sender, RoutedEventArgs e)
        {
            initialValue();
            timer.Start();
        }
        private void sbros_click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            initialValue();
        }
        private void initialValue()
        {
            var item = comboBoxTime.SelectedItem as ComboBoxItem;
            int minutes = 25;
            if (item != null)
            {
                minutes = int.Parse(item.Content.ToString());
            }
            stillTime = TimeSpan.FromMinutes(minutes);
            TimeText.Text = $"{stillTime:mm\\:ss}";
        }
    }
}
