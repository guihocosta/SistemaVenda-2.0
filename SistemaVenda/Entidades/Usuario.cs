using System.ComponentModel.DataAnnotations;
using Dominio.Entidades;

namespace SistemaVenda.Entidades
{
    public class Usuario : EntityBase
    {
        public string Nome {  get; set; }
        public string Email {  get; set; }
        public string Senha {  get; set; }
    }
}
