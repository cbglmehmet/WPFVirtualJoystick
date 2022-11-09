using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace virtualJoystick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _applicationStatus = true;
        public MainWindow()
        {
            InitializeComponent();
            Thread joystickValue = new Thread(new ThreadStart(joystickValue_DoWork));
            joystickValue.Start();
        }
        private void joystickValue_DoWork()
        {
            do
            {
                lblXValue.Dispatcher.Invoke(() =>
                {
                    lblXValue.Content = joystick.X;
                });
                lblYValue.Dispatcher.Invoke(() =>
                {
                    lblYValue.Content = joystick.Y;
                });
                Thread.Sleep(10);
            } while (_applicationStatus);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _applicationStatus = false;
        }
    }
}
