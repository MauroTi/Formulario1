using System;

namespace Formulario1.Models
{
    public class Rat
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}