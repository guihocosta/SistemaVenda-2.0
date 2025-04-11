using System.ComponentModel.DataAnnotations;
using Dominio.Entidades;

namespace SistemaVenda.Entidades
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }

    }
}
