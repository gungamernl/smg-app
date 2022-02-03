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

namespace SMG_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void nummers_click(object sender, RoutedEventArgs e)
        {
            nummers vk = new nummers();
            this.Close();
            vk.ShowDialog();

        }

        private void gebruikers_Click(object sender, RoutedEventArgs e)
        {
            gebruikers kp = new gebruikers();
            this.Close();
            kp.ShowDialog();

        }

        private void artiesten_Click(object sender, RoutedEventArgs e)
        {
            artiesten inf = new artiesten();
            this.Close();
            inf.ShowDialog();

        }
    }
}