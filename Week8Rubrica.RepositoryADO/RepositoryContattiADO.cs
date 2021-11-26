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
    public class RepositoryContattiADO : IRepositoryContatti
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Contatto Add(Contatto item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into Contatto values(@nome, @cognome)";
                    command.Parameters.AddWithValue("@nome", item.Nome);
                    command.Parameters.AddWithValue("@cognome", item.Cognome);


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

        public bool Delete(Contatto item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete Contatto where ID=@id";
                    command.Parameters.AddWithValue("@id", item.ID);
                    int rigaEliminata = command.ExecuteNonQuery();
                    if (rigaEliminata == 1)
                    {
                        connection.Close();
                        return true;

                    }
                    else
                    {
                        connection.Close();
                        return false;

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Contatto> GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Contatto";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Contatto> corsi = new List<Contatto>();

                    while (reader.Read())
                    {
                        var id = (int)reader["ID"];
                        var nome = (string)reader["Nome"];
                        var cognome = (string)reader["Cognome"];
                        Contatto c = new Contatto();
                        c.ID = id;
                        c.Nome = nome;
                        c.Cognome = cognome;
                        corsi.Add(c);
                    }
                    connection.Close();

                    return corsi;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Contatto>();
            }
        }

        public Contatto GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Contatto where ID=@id";
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Contatto c = null;

                    while (reader.Read())
                    {
                        //var id = (int)reader["ID"];
                        var nome = (string)reader["Nome"];
                        var cognome = (string)reader["Cognome"];
                       
                        c = new Contatto();
                        c.ID = id;
                        c.Nome = nome;
                        c.Cognome = cognome;                        
                    }
                    connection.Close();
                    return c;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
