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
using ClassLibrary;

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
            //Clear
            lbxResults.Items.Clear();
            //Load
            List<Library> mwrs = Library.GetAll();
            foreach (Library mwr in mwrs)
            {
                ListBoxItem li = new ListBoxItem();
                li.Content = mwr.ToString();
                li.Tag = mwr.Id;
                lbxResults.Items.Add(li);
            }
        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem li = (ListBoxItem)lbxResults.SelectedItem;
            if (li == null) return;
            int id = (int)li.Tag;
            Library mwd = Library.GetById(id);
            string firstname = mwd.Voornaam;
            string lastname = mwd.Achternaam;
            lblAchternaam.Content = lastname;
            lblVoornaam.Content = firstname;

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Ask Id
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            if (item == null) return;
            int employeeId = Convert.ToInt32(item.Tag);

            //Ask confirmation
            MessageBoxResult result = MessageBox.Show($"Ben je zeket dat je werknemer #{employeeId} wil verwijderen?", "Werknemer verwijderen", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            //Verwijder werknemer
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Contacts WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", employeeId);
                comm.ExecuteNonQuery();
                lbxResults.Items.Remove(lbxResults.SelectedItem);
            }
        }
    }
}
