using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace WpfBalieMedewerkers
{
    /// <summary>
    /// Logique d'interaction pour Medewerker.xaml
    /// </summary>
    public partial class Medewerker : Page
    {
        public Medewerker()
        {
            InitializeComponent();
        }
        string connString = ConfigurationManager.AppSettings["connString"];
        private void btnFetch_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam FROM Medewerker", conn);
                SqlDataReader reader = comm.ExecuteReader();
                lbxResults.Items.Clear();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string firstname = Convert.ToString(reader["voornaam"]);
                    string lastname = Convert.ToString(reader["achternaam"]);
                    ListBoxItem li = new ListBoxItem();
                    li.Tag = id;
                    li.Content = $"{id}: {firstname} {lastname}";
                    lbxResults.Items.Add(li);

                }
            }

        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem li = (ListBoxItem)lbxResults.SelectedItem;
            if (li == null) return;
            int id = (int)li.Tag;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam FROM Medewerker WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", id);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string firstname = Convert.ToString(reader["voornaam"]);
                string lastname = Convert.ToString(reader["achternaam"]);
                lblAchternaam.Content = lastname;
                lblVoornaam.Content = firstname;

            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
