using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorioFilmes.Models
{
    public class Repositorio
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string  Nome { get; set; }
        public string Descricao { get; set; }
        public string Duracao { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataLancamento { get; set; }
        public Estilo Estilo { get; set; }
    }
}
