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
    public class ServicoVenda : IServicoVenda
    {

        IRepositorioVenda Repositorio;

        public ServicoVenda(IRepositorioVenda repositorio)
        {
            Repositorio = repositorio;
        }

        public void Cadastrar(Venda ent)
        {
            Repositorio.Create(ent);
        }

        public Venda CarregarRegistro(int id)
        {
            return Repositorio.Read(id);
        }

        public void Excluir(int id)
        {
            Repositorio.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {
            return Repositorio.Read();
        }
    }
}
