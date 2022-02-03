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
using System.Windows.Shapes;
using System.Data;

namespace SMG_app
{
    /// <summary>
    /// Interaction logic for gebruikers.xaml
    /// </summary>
    public partial class gebruikers : Window
    {
        public gebruikers()
        {
            InitializeComponent();
            updatelistbox();
        }
        private void updatelistbox()
        {
            tb_gebruikersnaam.Clear();
            tb_voornaam.Clear();
            tb_achternaam.Clear();
            tb_email.Clear();
            tb_wachtwoord.Clear();


            DataTable datatable = database.get_gebruikers();

            lb_gebruikers.ItemsSource = datatable.DefaultView;

        }
        private void update_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_gebruikersnaam.Text) && !string.IsNullOrWhiteSpace(tb_voornaam.Text) && !string.IsNullOrWhiteSpace(tb_achternaam.Text) && !string.IsNullOrWhiteSpace(tb_wachtwoord.Text) &&  !string.IsNullOrWhiteSpace(tb_email.Text) && lb_gebruikers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_gebruikers.SelectedItem as DataRowView;
                string gebruikersid = selectedrow["gebruiker_id"].ToString();
                database.updategebruiker(tb_gebruikersnaam.Text, tb_voornaam.Text, tb_voornaam.Text, tb_email.Text,tb_wachtwoord.Text , gebruikersid);
                updatelistbox();
            }
        }
        private void insert_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_gebruikersnaam.Text) && !string.IsNullOrWhiteSpace(tb_voornaam.Text) && !string.IsNullOrWhiteSpace(tb_achternaam.Text) && !string.IsNullOrWhiteSpace(tb_wachtwoord.Text) && !string.IsNullOrWhiteSpace(tb_email.Text))
            {

                database.insertgebruiker(tb_gebruikersnaam.Text, tb_voornaam.Text, tb_voornaam.Text, tb_email.Text, tb_wachtwoord.Text);
                updatelistbox();
            }
        }
        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (lb_gebruikers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_gebruikers.SelectedItem as DataRowView;
                string gebruikersid = selectedrow["gebruiker_id"].ToString();
                database.deletegebruiker(gebruikersid);
                updatelistbox();
            }
        }
        private void lb_gebruikers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_gebruikers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_gebruikers.SelectedItem as DataRowView;
                tb_gebruikersnaam.Text = selectedrow["gebruikersnaam"].ToString();
                tb_voornaam.Text = selectedrow["voornaam"].ToString();
                tb_achternaam.Text = selectedrow["achternaam"].ToString();
                tb_email.Text = selectedrow["email"].ToString();
                tb_wachtwoord.Text = selectedrow["wachtwoord"].ToString();


            }
        }

        private void terug_click(object sender, RoutedEventArgs e)
        {
            MainWindow vk = new MainWindow();
            this.Close();
            vk.ShowDialog();
        }
    }
}
