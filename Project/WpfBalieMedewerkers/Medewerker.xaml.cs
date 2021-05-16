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
            ReloadEmployees(null);
        }
        string connString = ConfigurationManager.AppSettings["connString"];
        public void ReloadEmployees(int? selectedId)
        {
            // wis de lijst
            lbxResults.Items.Clear();

            // laad alle werknemers in
            List<Library> allEmps = Library.GetAll();
            foreach (Library emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                lbxResults.Items.Add(item);
            }
        }

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
            // vraag id geselecteerde werknemer op
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            int employeeId = Convert.ToInt32(item.Tag);
            Library emp = Library.FindById(employeeId);

            // vraag bevestiging
            MessageBoxResult result = MessageBox.Show($"Ben je zeker dat je werknemer #{employeeId} wil verwijderen?", "Werknemer verwijderen", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            // verwijder werknemer
            emp.DeleteFromDb();
            ReloadEmployees(null);
        
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            int employeeId = Convert.ToInt32(item.Tag);
            EditWindow editWin = new EditWindow(this, employeeId);
            editWin.Show();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Insert newWin = new Insert(this);
            newWin.Show();
        }
    }
}
