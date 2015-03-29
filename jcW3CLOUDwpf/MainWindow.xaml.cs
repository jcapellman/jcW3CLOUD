using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jcW3CLOUDwpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private JCW3CLOUDReference.JCW3CLOUDClient _client = new JCW3CLOUDReference.JCW3CLOUDClient();
        private Random rnd = new Random(DateTime.Now.Second);

        public MainWindow() {
            InitializeComponent();    
        }

        private int getUniqueID() {
            return rnd.Next(int.MaxValue);
        }

        private void getPage(string url) {
            var page = _client.renderPage(url);

            int request = getUniqueID();
 
            StreamWriter sw = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + request + ".html");
            sw.Write(page.HTML);
            sw.Close();

            wbMain.Navigate(System.AppDomain.CurrentDomain.BaseDirectory + request + ".html");
        }

        private void txtURL_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                getPage(txtURL.Text);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            App.Current.Shutdown();
        }

        private void dpTitleBar_MouseDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e) {
            switch (WindowState) {
                case System.Windows.WindowState.Maximized:
                    WindowState = System.Windows.WindowState.Normal;
                    break;
                default:
                    WindowState = System.Windows.WindowState.Maximized;
                    break;
            }            
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
