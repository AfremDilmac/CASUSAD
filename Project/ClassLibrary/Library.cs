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
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        //methodes
        public static List<Library> GetAll() {
            List<Library> mwrs = new List<Library>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam FROM Medewerker", conn);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string firstname = Convert.ToString(reader["voornaam"]);
                    string lastname = Convert.ToString(reader["achternaam"]);
                    mwrs.Add(new Library(id, firstname, lastname));
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
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam FROM Medewerker WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", empId);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk resultaten
                if (!reader.Read()) return null;
                int id = Convert.ToInt32(reader["id"]);
                string firstname = Convert.ToString(reader["voornaam"]);
                string lastname = Convert.ToString(reader["achternaam"]);
                return new Library(id, firstname, lastname);
            }
        }

        public static Library GetById(int id) {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam FROM Medewerker WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", id);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string firstname = Convert.ToString(reader["voornaam"]);
                string lastname = Convert.ToString(reader["achternaam"]);
                return new Library(id, firstname, lastname);
            }
        }

        public void DeleteFromDb() {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Medewerker WHERE ID = @par1", conn);
                comm.Parameters.AddWithValue("@par1", Id);
                comm.ExecuteNonQuery();
            }
        }

        public void UpdateInDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                    @"UPDATE Medewerker
                        SET voornaam=@parF, achternaam=@parL
                        WHERE ID = @parID"
                    , conn);
                comm.Parameters.AddWithValue("@parF", Voornaam);
                comm.Parameters.AddWithValue("@parL", Achternaam);
                comm.Parameters.AddWithValue("@parID", Id);
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
        public Library(int id, string vn, string an)
        {
            Id = id;
            Voornaam = vn;
            Achternaam = an;
        }
        public override string ToString()
        {
            return $"{Id}: {Voornaam} {Achternaam}";

        }

    }
}
