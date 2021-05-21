using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Library
    {
        //variable
        private static string connString = ConfigurationManager.AppSettings["connString"];
        //properities
        public int Lidnummer {get; set;}
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Geboortedatum { get; set; }
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Vervaldatum_Lidkaart { get; set; }
        public string Gsm { get; set; }

        //methodes
        public static List<Library> GetAll() {
            List<Library> mwrs = new List<Library>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT lidnummer, voornaam, achternaam, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm FROM Lid", conn);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    int lidnummer = Convert.ToInt32(reader["lidnummer"]);
                    string firstname = Convert.ToString(reader["voornaam"]);
                    string lastname = Convert.ToString(reader["achternaam"]);
                    string geboortedatum = Convert.ToString(reader["geboortedatum"]);
                    string straat = Convert.ToString(reader["straat"]);
                    int nummer = Convert.ToInt32(reader["nummer"]);
                    int postcode = Convert.ToInt32(reader["postcode"]);
                    string gemeente = Convert.ToString(reader["gemeente"]);
                    string vervaldatum_lidkaart = Convert.ToString(reader["vervaldatum_lidkaart"]);
                    string gsm = Convert.ToString(reader["gsm"]);


                    mwrs.Add(new Library(lidnummer, firstname, lastname, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm));
                }

            }
            return mwrs;
        }

        public static Library FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT lidnummer, voornaam, achternaam, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm FROM Lid WHERE lidnummer = @par1", conn);
                comm.Parameters.AddWithValue("@par1", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                int lidnummer = Convert.ToInt32(reader["lidnummer"]); ;
                string firstname = Convert.ToString(reader["voornaam"]);
                string lastname = Convert.ToString(reader["achternaam"]);
                string geboortedatum = Convert.ToString(reader["geboortedatum"]);
                string straat = Convert.ToString(reader["straat"]);
                int nummer = Convert.ToInt32(reader["nummer"]);
                int postcode = Convert.ToInt32(reader["postcode"]);
                string gemeente = Convert.ToString(reader["gemeente"]);
                string vervaldatum_lidkaart = Convert.ToString(reader["vervaldatum_lidkaart"]);
                string gsm = Convert.ToString(reader["gsm"]);
                return new Library(lidnummer, firstname, lastname, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm);
            }
        }

        public static Library GetById(int id) {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT lidnummer, voornaam, achternaam, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm FROM Lid WHERE lidnummer = @par1", conn);
                comm.Parameters.AddWithValue("@par1", id);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string firstname = Convert.ToString(reader["voornaam"]);
                string lastname = Convert.ToString(reader["achternaam"]);
                string geboortedatum = Convert.ToString(reader["geboortedatum"]);
                string straat = Convert.ToString(reader["straat"]);
                int nummer = Convert.ToInt32(reader["nummer"]);
                int postcode = Convert.ToInt32(reader["postcode"]);
                string gemeente = Convert.ToString(reader["gemeente"]);
                string vervaldatum_lidkaart = Convert.ToString(reader["vervaldatum_lidkaart"]);
                string gsm = Convert.ToString(reader["gsm"]);
                return new Library(id, firstname, lastname, geboortedatum, straat, nummer, postcode, gemeente, vervaldatum_lidkaart, gsm);
            }
        }

        public void DeleteFromDb() {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Lid WHERE lidnummer = @par1", conn);
                comm.Parameters.AddWithValue("@par1", Lidnummer);
                comm.ExecuteNonQuery();
            }
        }

        public void UpdateInDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                    @"UPDATE Lid
                        SET voornaam=@parF, achternaam=@parL
                        WHERE lidnummer = @parID"
                    , conn);
                comm.Parameters.AddWithValue("@parF", Voornaam);
                comm.Parameters.AddWithValue("@parL", Achternaam);
                comm.Parameters.AddWithValue("@parID", Lidnummer);
                comm.ExecuteNonQuery();
            }
        }

        public int InsertInDb() {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                  "INSERT INTO Medewerker(voornaam,achternaam) output INSERTED.ID VALUES(@par1,@par2)", conn);
                comm.Parameters.AddWithValue("@par1", Voornaam);
                comm.Parameters.AddWithValue("@par2", Achternaam);
                return (int)comm.ExecuteScalar();
            }
        }

        //constructors
        public Library()
        { 
        }
        //Medewerkers
        public Library(int lidnummer, string vn, string an)
        {
            Lidnummer = lidnummer;
            Voornaam = vn;
            Achternaam = an;
        }

        public Library(int lidnummer, string vn, string an, string geboortedatum, string straat, int nummer, int postcode, string gemeente, string vervaldatum_lidkaart, string gsm) : this(lidnummer, vn, an)
        {
            Geboortedatum = geboortedatum;
            Straat = straat;
            Nummer = nummer;
            Postcode = postcode;
            Gemeente = gemeente;
            Vervaldatum_Lidkaart = vervaldatum_lidkaart;
            Gsm = gsm;
        }

        public override string ToString()
        {
            return $"{Lidnummer}: {Voornaam} {Achternaam}";

        }

    }
}
