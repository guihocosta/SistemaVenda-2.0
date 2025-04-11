using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Interfaces.Repositorio;
using SistemaVenda.Dominio.Entidades;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {

        IRepositorioProduto Repositorio;

        public ServicoProduto(IRepositorioProduto repositorio)
        {
            Repositorio = repositorio;
        }

        public void Cadastrar(Produto ent)
        {
            Repositorio.Create(ent);
        }

        public Produto CarregarRegistro(int id)
        {
            return Repositorio.Read(id);
        }

        public void Excluir(int id)
        {
            Repositorio.Delete(id);
        }

        public IEnumerable<Produto> Listagem()
        {
            return Repositorio.Read();
        }
    }
}
