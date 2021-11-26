using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.InterfaceRepositories;

namespace Week8Rubrica.RepositoryADO
{
    public class RepositoryIndirizziADO : IRepositoryIndirizzi
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Indirizzo Add(Indirizzo item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into Indirizzo values(@tipologia, @via, @citta, @cap, @provincia, @nazione, @contatto)";
                    command.Parameters.AddWithValue("@tipologia", item.Tipologia);
                    command.Parameters.AddWithValue("@via", item.Via);
                    command.Parameters.AddWithValue("@citta", item.Citta);
                    command.Parameters.AddWithValue("@cap", item.CAP);
                    command.Parameters.AddWithValue("@provincia", item.Provincia);
                    command.Parameters.AddWithValue("@nazione", item.Nazione);
                    command.Parameters.AddWithValue("@contatto", item.ContattoID);

                    int numRighe = command.ExecuteNonQuery();
                    if (numRighe == 1)
                    {
                        connection.Close();
                        return item;
                    }
                    connection.Close();
                    return item;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Indirizzo> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Indirizzo";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Indirizzo> indirizzi = new List<Indirizzo>();

                    while (reader.Read())
                    {
                        var id = (int)reader["ID"];
                        var tipologia = (string)reader["Tipologia"];
                        var via = (string)reader["Via"];
                        var citta = (string)reader["Citta"];
                        var cap = (string)reader["CAP"];
                        var provincia = (string)reader["Provincia"];
                        var nazione = (string)reader["Nazione"];
                        var contattoId = (int)reader["ContattoID"];

                        var i = new Indirizzo();
                        i.ID = id;
                        i.Tipologia = tipologia;
                        i.Via = via;
                        i.Citta = citta;
                        i.CAP = cap;
                        i.Nazione = nazione;
                        i.Provincia = provincia;
                        i.ContattoID = contattoId;

                        indirizzi.Add(i);
                    }
                    connection.Close();

                    return indirizzi;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Indirizzo>();
            }
        }
    }
}
  