using System;
using System.Data;
using System.Collections.Generic;
using Npgsql;
using Teste_BD.Model;

namespace Teste_BD.Persistence
{
    public class PersonPersistence : IPersonPersistence
    {
        private string strCon = string.Format("Server=;Port=;" +
            "User id=;Password=;Database=Teste");

        /// <summary>
        /// Function Deletar pessoa
        /// </summary>
        /// <param name="id"></param>
        /// Função para deletar pessoa        
        public void DeletePerson(int id)
        {
            var query = "DELETE FROM person WHERE person_id = " + id;

            var con = new NpgsqlConnection(strCon);
            var cmd = new NpgsqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Pessoa deletada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Function Listar todos
        /// </summary>
        /// <returns>Uma lista de objetos pessoa</returns>
        public IEnumerable<PersonModel> GetAll()
        {
            var query = "SELECT * FROM person";
            var con = new NpgsqlConnection(strCon);
            var cmd = new NpgsqlCommand(query, con);            
            con.Open();            
            var people = new List<PersonModel>();
            
            NpgsqlDataReader rd = cmd.ExecuteReader();
            try
            {
                while (rd.Read())
                {
                    var person = new PersonModel();
                    {
                        person.Id = int.Parse(rd["person_id"].ToString());
                        person.Name = rd["person_name"].ToString();
                        person.Age = int.Parse(rd["age"].ToString());
                        person.Skills = rd["skills"].ToString();                            
                    }
                    people.Add(person);                
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }
            finally
            {
                con.Close();
            }           
            return people;
        }
        /// <summary>
        /// Function Pegar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto pessoa</returns>
        public PersonModel GetById(int id)
        {
            var query = "SELECT * FROM person WHERE person_id =" + id;

            NpgsqlConnection con = new NpgsqlConnection(strCon);
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataReader rd = cmd.ExecuteReader();
            PersonModel person = null;

            while (rd.Read())
            {
                person = new PersonModel();
                {
                    person.Id = int.Parse(rd["person_id"].ToString());
                    person.Name = rd["person_name"].ToString();
                    person.Age = int.Parse(rd["age"].ToString());
                    person.Skills = rd["skills"].ToString();
                }
            }
            return person;            
        }
        /// <summary>
        /// Function Inserir pessoa
        /// </summary>
        /// <param name="person"></param>
        public void InsertPerson(PersonModel person)
        {

            var query = "INSERT INTO person (person_name,age,skills) " +
                    "VALUES ('" + person.Name + "'," + person.Age + ",'" + person.Skills + "')";

            NpgsqlConnection con = new NpgsqlConnection(strCon);
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            //using (NpgsqlConnection con = new NpgsqlConnection(strCon))
            //{


            //var data = new NpgsqlDataAdapter();


            //con.Open();
            //var query = string.Format("INSERT INTO person (person_name, age, skills) " +
            //"VALUES ({0}, {1}, {2});", person.Name, person.Age, person.Skills);
            //cmd = new NpgsqlCommand(query);
            //data.InsertCommand = cmd;
            //cmd.Connection = con;
            //data.InsertCommand.ExecuteNonQuery();
            //con.Close();
            //Console.WriteLine("Person inserted");
            //}                        
        }
    }
}
