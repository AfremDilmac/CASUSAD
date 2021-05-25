using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Data;



namespace ItemsLibrary
{
    public class Items
    {
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public Byte[] Coverfoto { get; set; }
        public string Uitgeverij { get; set; }
        public int Leeftijd_van { get; set; }
        public int Leeftijd_tot { get; set; }
        public string Taal { get; set; }



        public Items()
        {
        }
        public Items(int id, string titel, string beschrijving)
        {
            Id = id;
            Titel = titel;
            Beschrijving = beschrijving;
        }
        public Items(int id, string titel, string beschrijving, Byte[] coverfoto, string uitgeverij, int leeftijd_van, int leeftijd_tot, string taal) : this(id, titel, beschrijving)
        {
            Coverfoto = coverfoto;
            Uitgeverij = uitgeverij;
            Leeftijd_van = leeftijd_van;
            Leeftijd_tot = leeftijd_tot;
            Taal = taal;

        }

        public static List<Items> GetAll()
        {
            List<Items> emps = new List<Items>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT id, titel, beschrijving FROM Items", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string titel = Convert.ToString(reader["titel"]);
                    string beschrijving = Convert.ToString(reader["beschrijving"]);
                    emps.Add(new Items(id, titel, beschrijving));
                }
            }
            return emps;
        }
        public static Items FindById(int empId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT titel, beschrijving, coverfoto, uitgeverij, leeftijd_van, leeftijd_tot, taal FROM Items WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                string titel = Convert.ToString(reader["titel"]);
                string beschrijving = Convert.ToString(reader["beschrijving"]);
                string uitgeverij = Convert.ToString(reader["uitgeverij"]);
                int leeftijd_van = Convert.ToInt32(reader["leeftijd_van"]);
                int leeftijd_tot = Convert.ToInt32(reader["leeftijd_tot"]);
                string taal = Convert.ToString(reader["taal"]);
                return new Items();
            }
        }

        public override string ToString()
        {
        return $"{Id}: {Titel} {Beschrijving}";

        }

    }
}
