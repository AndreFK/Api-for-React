using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication6.Models;
using MySql.Data.MySqlClient;

namespace WebApplication6.Controllers
{
    public class ValuesController : ApiController
    {
        private string scon = "server=localhost;uid=root;pwd=system;database=testschema";

        // GET api/values
        public List<Nota> Get()
        {
            MySqlConnection conn = new MySqlConnection(scon);
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from notas", conn);
                reader = cmd.ExecuteReader();
                List<Nota> notas = new List<Nota>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string cont = reader.GetString(1);
                    notas.Add(new Nota(cont, id));
                }
                conn.Close();
                return notas;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/values
        public void Post(Nota n)
        {
            MySqlConnection conn = new MySqlConnection(scon);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "insert into notas values (@id, @Cont)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", n.idnota);
                cmd.Parameters.AddWithValue("@Cont", n.Content);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }
        
        // PUT api/values/5
        public void Put(Nota n)
        {
            MySqlConnection conn = new MySqlConnection(scon);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "update notas set contenido = @cont where idnotas = @id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", n.idnota);
                cmd.Parameters.AddWithValue("@cont", n.Content);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(scon);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "delete from notas where idnotas = @id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }
    }
}
