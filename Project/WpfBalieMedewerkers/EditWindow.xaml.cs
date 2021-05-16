﻿using System;
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
using System.Windows.Shapes;
using ClassLibrary;

namespace WpfBalieMedewerkers
{
    /// <summary>
    /// Logique d'interaction pour EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        // referentie naar hoofdvenster en werknemer id
        Medewerker mainWin;
        Library emp;
        // connectiestring nodig om te connecteren met de databank
        string connString = ConfigurationManager.AppSettings["connString"];

        public EditWindow(Medewerker mainWin, int id)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            this.Title = $"Werknemer #{id} bewerken";
            emp = Library.FindById(id);
            txtFirst.Text = emp.Voornaam;
            txtLast.Text = emp.Achternaam;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // sluit dit venster
            this.Close();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                emp.Voornaam = txtFirst.Text;
                emp.Achternaam = txtLast.Text;
                emp.UpdateInDb();
            }

            // herlaad hoofdvenster, en sluit dit venster
            mainWin.ReloadEmployees(emp.Id);
            this.Close();
        }
    }
}
