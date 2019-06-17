using System.Data;
using System.Data.SqlClient;

namespace MinhaWebAPI.Util
{
    public class DAL
    {
        private static readonly string Server = @"RI-DEV-03\SQLEXPRESS";
        private static readonly string Database = "MVCTeste";
        private static readonly string User = "candidato";
        private static readonly string Password = "Teste123";
        private readonly SqlConnection Connection;

        private readonly string ConnectionString = $"Server={Server};Database={Database};User Id={User};Password={Password};";

        public DAL() {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        public DataTable RetornarDataTable(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, Connection);
            SqlDataAdapter DataAdaptar = new SqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptar.Fill(Dados);
            return Dados;
        }
    }
}
