using System;
using Npgsql;

namespace Teste_BD.Persistence
{
    public class Connection
    {
        private string strCon = string.Format("Server=127.0.0.1;Port=5432;" +
            "User id=postgres;Password=abc,12345678;Database=Teste");

        private NpgsqlConnection con = null;

        public void OpenCon()
        {
            con = new NpgsqlConnection(strCon);         
            con.Open();        

        }

        public void CloseCon()
        {
            con = new NpgsqlConnection(strCon);
            con.Close();
        }
    }
}