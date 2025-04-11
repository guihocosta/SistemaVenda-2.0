using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext){
        }

        public override IEnumerable<Produto> Read()
        {
            return DbSetContext.AsNoTracking()
                .Include(x => x.Categoria)
                .ToList();
        }

        public override Produto Read(int id)
        {
            return DbSetContext
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Codigo == id);
        }
    }
}
