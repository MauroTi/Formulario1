using MySql.Data.MySqlClient;
using System;

namespace Formulario1.DAO
{
    public class ConexaoDAO
    {
        private MySqlConnection conexao;

        private string stringConexao = "server=localhost;database=erpalfa;uid=root;pwd=;";

        public MySqlConnection Conectar()
        {
            try
            {
                conexao = new MySqlConnection(stringConexao);
                conexao.Open();
                Console.WriteLine("Conexão realizada com sucesso!");
                return conexao;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
                return null;
            }
        }

        public void Desconectar()
        {
            if (conexao != null)
            {
                conexao.Close();
                Console.WriteLine("Conexão encerrada.");
            }
        }
    }
}
