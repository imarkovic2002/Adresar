using MySqlConnector;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik.DB.Store
{
    public class OsobaStore
    {
        public List<Korisnik> GetKorisnik()
        {
            var connectionManager = new SqlConnectionFactory();
            List<Korisnik> userList = new List<Korisnik>();

            using (var connection = connectionManager.GetNewConnection())
            {
                if (connection != null)
                {
                    string upit = String.Format("SELECT * FROM korisnici");
                    using (var command = new MySqlCommand(upit, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Korisnik korisnik = new Korisnik();
                                korisnik.Ime = reader.GetString("ime");
                                korisnik.Prezime = reader.GetString("prezime");
                                korisnik.Adresa = reader.GetString("adresa");
                                korisnik.Telefonski_broj = reader.GetString("telefonski_broj");

                                userList.Add(korisnik);

                            }
                        }
                    }
                }
                connectionManager.CloseConnection(connection);
            }
            return userList.OrderBy(korisnik => korisnik.Prezime).ToList();
        }
        public void DodajKorisnika(Korisnik korisnik)
        {
            var connectionManager = new SqlConnectionFactory();
            using (var connection = connectionManager.GetNewConnection())
            {
                if (connection != null)
                {
                    string upit = "INSERT INTO korisnici(ime,prezime,adresa,telefonski_broj) VALUES (@Ime, @Prezime, @Adresa, @Telefonski_broj)";
                    using (var command = new MySqlCommand(upit, connection))
                    {
                        command.Parameters.AddWithValue("@Ime", korisnik.Ime);
                        command.Parameters.AddWithValue("@Prezime", korisnik.Prezime);
                        command.Parameters.AddWithValue("@Adresa", korisnik.Adresa);
                        command.Parameters.AddWithValue("@Telefonski_broj", korisnik.Telefonski_broj);

                        command.ExecuteNonQuery();
                    }
                    connectionManager.CloseConnection(connection);
                }
            }
        }

        public void AzurirajKorisnika(Korisnik korisnik)
        {
            var connectionManager = new SqlConnectionFactory();
            using (var connection = connectionManager.GetNewConnection())
            {
                if (connection != null)
                {
                    string upit = "UPDATE korisnici SET ime = @Ime, prezime = @Prezime, adresa = @Adresa, telefonski_broj = @Telefonski_broj WHERE ime = @Ime AND prezime = @Prezime";
                    using (var command = new MySqlCommand(upit, connection))
                    {
                        command.Parameters.AddWithValue("@Ime", korisnik.Ime);
                        command.Parameters.AddWithValue("@Prezime", korisnik.Prezime);
                        command.Parameters.AddWithValue("@Adresa", korisnik.Adresa);
                        command.Parameters.AddWithValue("@Telefonski_broj", korisnik.Telefonski_broj);

                        command.ExecuteNonQuery();
                    }
                    connectionManager.CloseConnection(connection);
                }
            }
        }

        public void IzbrisiKorisnika(Korisnik korisnik)
        {
            var connectionManager = new SqlConnectionFactory();
            using (var connection = connectionManager.GetNewConnection())
            {
                if (connection != null)
                {
                    string upit = "DELETE * FROM korisnici WHERE ime = @Ime AND prezime = @Prezime";
                    using (var command = new MySqlCommand(upit, connection))
                    {
                        command.Parameters.AddWithValue("@Ime", korisnik.Ime);
                        command.Parameters.AddWithValue("@Prezime", korisnik.Prezime);
                        command.ExecuteNonQuery();
                    }
                    connectionManager.CloseConnection(connection);
                }
            }
        }
        public List<Korisnik> Pretrazivanje(string pretraga)
        {
            var osobaStore = new OsobaStore();
            var osobe = osobaStore.GetKorisnik();
            List<Korisnik> rezultati = osobe.Where(korisnik => korisnik.Ime.IndexOf(pretraga, StringComparison.OrdinalIgnoreCase) >= 0 ||
            korisnik.Prezime.IndexOf(pretraga, StringComparison.OrdinalIgnoreCase) >= 0 ||
            korisnik.Telefonski_broj.IndexOf(pretraga, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            return rezultati;
        }
    }
}
