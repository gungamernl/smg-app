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
    /// Interaction logic for nummers.xaml
    /// </summary>
    public partial class nummers : Window
    {
        public nummers()
        {
            InitializeComponent();
            updatelistbox();
        }
        private void updatelistbox()
        {
            tb_nummernaam.Clear();
            tb_nummerlink.Clear();
            tb_artiest.Clear();
            DataTable datatable =database.get_nummers();

            lb_nummers.ItemsSource = datatable.DefaultView;
        }

        private void Lb_nummers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_nummers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_nummers.SelectedItem as DataRowView;
                tb_nummernaam.Text = selectedrow["nummer_naam"].ToString();
                tb_nummerlink.Text = selectedrow["nummer_link"].ToString();
                tb_artiest.Text = selectedrow["artiest_naam"].ToString();
                string nummerid = selectedrow["nummer_id"].ToString();
            }
        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_nummernaam.Text) && !string.IsNullOrWhiteSpace(tb_nummerlink.Text) && lb_nummers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_nummers.SelectedItem as DataRowView;
                string nummerid = selectedrow["nummer_id"].ToString();
                database.updatenummer(tb_nummerlink.Text, tb_nummernaam.Text, nummerid);
                updatelistbox();
            }
        }
        private void insert_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_nummernaam.Text) && !string.IsNullOrWhiteSpace(tb_nummerlink.Text))
            {

                database.insertnummer(tb_nummerlink.Text, tb_nummernaam.Text);
                updatelistbox();
            }
        }
        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (lb_nummers.SelectedItem != null)
            {
                DataRowView selectedrow = lb_nummers.SelectedItem as DataRowView;
                string nummerid = selectedrow["nummer_id"].ToString();
                database.deletenummer(nummerid);
                updatelistbox();
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
