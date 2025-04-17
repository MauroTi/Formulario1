using MySql.Data.MySqlClient;
using Formulario1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formulario1.DAO
{
    public class RatDao
    {
        private ConexaoDAO conexaoDao = new ConexaoDAO();

        public List<Rat> Listar(string nome = null, string sobrenome = null, string email = null, string cidade = null, string estado = null)
        {
            var lista = new List<Rat>();
            var conn = conexaoDao.Conectar();
            var sb = new StringBuilder();
            sb.Append("SELECT * FROM Rat");

            var filtros = new List<string>();
            if (!string.IsNullOrEmpty(nome)) filtros.Add("nome LIKE @nome");
            if (!string.IsNullOrEmpty(sobrenome)) filtros.Add("sobrenome LIKE @sobrenome");
            if (!string.IsNullOrEmpty(email)) filtros.Add("email LIKE @email");
            if (!string.IsNullOrEmpty(cidade)) filtros.Add("cidade LIKE @cidade");
            if (!string.IsNullOrEmpty(estado)) filtros.Add("estado = @estado");

            if (filtros.Count > 0)
                sb.Append(" WHERE " + string.Join(" AND ", filtros));

            using (var cmd = new MySqlCommand(sb.ToString(), conn))
            {
                if (!string.IsNullOrEmpty(nome)) cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                if (!string.IsNullOrEmpty(sobrenome)) cmd.Parameters.AddWithValue("@sobrenome", "%" + sobrenome + "%");
                if (!string.IsNullOrEmpty(email)) cmd.Parameters.AddWithValue("@email", "%" + email + "%");
                if (!string.IsNullOrEmpty(cidade)) cmd.Parameters.AddWithValue("@cidade", "%" + cidade + "%");
                if (!string.IsNullOrEmpty(estado)) cmd.Parameters.AddWithValue("@estado", estado);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Rat
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            Sobrenome = reader.GetString("sobrenome"),
                            Email = reader.GetString("email"),
                            Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? null : reader.GetString("telefone"),
                            Endereco = reader.IsDBNull(reader.GetOrdinal("endereco")) ? null : reader.GetString("endereco"),
                            Cidade = reader.IsDBNull(reader.GetOrdinal("cidade")) ? null : reader.GetString("cidade"),
                            Estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? null : reader.GetString("estado"),
                            Cep = reader.IsDBNull(reader.GetOrdinal("cep")) ? null : reader.GetString("cep"),
                            DataNascimento = reader.IsDBNull(reader.GetOrdinal("dataNascimento")) ? (DateTime?)null : reader.GetDateTime("dataNascimento"),
                            Genero = reader.IsDBNull(reader.GetOrdinal("genero")) ? null : reader.GetString("genero"),
                            Observacoes = reader.IsDBNull(reader.GetOrdinal("observacoes")) ? null : reader.GetString("observacoes"),
                            DataCadastro = reader.GetDateTime("dataCadastro")
                        });
                    }
                }
            }
            conexaoDao.Desconectar();
            return lista;
        }
    }
}
