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
    /// Interaction logic for artiesten.xaml
    /// </summary>
    public partial class artiesten : Window
    {
        public artiesten()
        {
            InitializeComponent();
            updatelistbox();
        }
        private void updatelistbox()
        {
            tb_artiestnaam.Clear();
            tb_artiestfoto.Clear();
            tb_infoartiest.Clear();
            tb_artiestlink.Clear();

            DataTable datatable = database.getongekoppeldnummer();
            DataTable datatable2 = database.getartiesten();

            lb_ongekoppelde.ItemsSource = datatable.DefaultView;
            lb_artiesten.ItemsSource = datatable2.DefaultView;
        }
        private void Lb_artiesten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_artiesten.SelectedItem != null)
            {
                DataRowView selectedrow = lb_artiesten.SelectedItem as DataRowView;
                tb_artiestnaam.Text = selectedrow["artiest_naam"].ToString();
                tb_artiestfoto.Text = selectedrow["artiestfoto"].ToString();
                tb_infoartiest.Text = selectedrow["info_artiest"].ToString();
                tb_artiestlink.Text = selectedrow["artiest_link"].ToString();
                string artiest_id = selectedrow["artiest_id"].ToString();
                database.get_gekoppeld(artiest_id);

                updatenummers2(artiest_id);

            }
        }
        private void updatenummers2(string artiest_id)
        {

            DataTable datatable = database.get_gekoppeld(artiest_id);
            lb_gekoppeld.ItemsSource = datatable.DefaultView;
        }

        private void ontkoppel_Click(object sender, RoutedEventArgs e)
        {
            if (lb_gekoppeld.SelectedItem != null)
            {
                DataRowView selectedrow = lb_gekoppeld.SelectedItem as DataRowView;
                string nummerid = selectedrow["nummer_id"].ToString();
                database.ontkoppel_nummer(nummerid);
                updatelistbox();

            }
        }

        private void koppel_Click(object sender, RoutedEventArgs e)
        {
            if (lb_ongekoppelde.SelectedItem != null && lb_artiesten.SelectedItem != null)
            {
                DataRowView selectedrow = lb_ongekoppelde.SelectedItem as DataRowView;
                string nummerid = selectedrow["nummer_id"].ToString();
                DataRowView selectedrow2 = lb_artiesten.SelectedItem as DataRowView;
                string artiestid = selectedrow2["artiest_id"].ToString();
                database.koppel_nummer(nummerid, artiestid);
                updatelistbox();
            }

        }
        private void update_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_artiestnaam.Text) && !string.IsNullOrWhiteSpace(tb_artiestfoto.Text) && !string.IsNullOrWhiteSpace(tb_infoartiest.Text) && !string.IsNullOrWhiteSpace(tb_artiestlink.Text) && lb_artiesten.SelectedItem != null)
            {
                DataRowView selectedrow = lb_artiesten.SelectedItem as DataRowView;
                string artiestid = selectedrow["artiest_id"].ToString();
                database.updateartiest(tb_artiestnaam.Text, tb_artiestfoto.Text, tb_infoartiest.Text, tb_artiestlink.Text, artiestid);
                updatelistbox();
            }
        }
        private void insert_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_artiestnaam.Text) && !string.IsNullOrWhiteSpace(tb_artiestfoto.Text) && !string.IsNullOrWhiteSpace(tb_infoartiest.Text) && !string.IsNullOrWhiteSpace(tb_artiestlink.Text))
            {

                database.insertartiest(tb_artiestnaam.Text, tb_artiestfoto.Text, tb_infoartiest.Text, tb_artiestlink.Text);
                updatelistbox();
            }
        }
        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (lb_artiesten.SelectedItem != null)
            {
                DataRowView selectedrow = lb_artiesten.SelectedItem as DataRowView;
                string artiestid = selectedrow["artiest_id"].ToString();
                database.deleteartiest(artiestid);
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
