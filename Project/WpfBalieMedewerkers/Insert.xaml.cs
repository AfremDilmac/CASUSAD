using System;
using System.Collections.Generic;
using System.Configuration;
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
using ClassLibrary;

namespace WpfBalieMedewerkers
{
    /// <summary>
    /// Logique d'interaction pour Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        // referentie naar hoofdvenster
        Medewerker mainWin;

        // connectiestring nodig om te connecteren met de databank
        string connString = ConfigurationManager.AppSettings["connString"];
        public Insert(Medewerker mainWin)
        {
            InitializeComponent();
            this.mainWin = mainWin;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // sluit dit venster
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstname = txtFirst.Text;
            string lastname = txtLast.Text;
            Library emp = new Library(0, firstname, lastname);
            int newId = emp.InsertInDb();

            // herlaad hoofdvenster, en sluit dit venster
            mainWin.ReloadEmployees(newId);
            this.Close();
        }
    }
}
