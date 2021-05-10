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

namespace WpfBalieMedewerkers
{
    /// <summary>
    /// Logique d'interaction pour LoginWindowWindow1.xaml
    /// </summary>
    public partial class LoginWindowWindow1 : Window
    {
        string connString = ConfigurationManager.AppSettings["connString"];
        public LoginWindowWindow1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT  code_pasje, passwoord FROM Medewerker", conn);
                SqlDataReader reader = comm.ExecuteReader();
        
                while (reader.Read())
                {
                    string code = Convert.ToString(reader["code_pasje"]);
                    string passwoord = Convert.ToString(reader["passwoord"]);

                    if (tbxGebruikersnaam.Text == code && tbxWachtwoord.Text == passwoord)
                    {
                        MainWindow sW = new MainWindow();
                        sW.Show();
                        this.Close();
                    }
                    else
                    {
                        lblError.Content = "Gebruikersnaam en/of wachtwoord is fout.";
                    }
                }
            }


        }
    }
}
