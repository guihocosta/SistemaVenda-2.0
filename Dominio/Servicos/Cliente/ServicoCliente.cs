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
    public class ServicoCliente : IServicoCliente
    {

        IRepositorioCliente RepositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }

        public void Cadastrar(Cliente Cliente)
        {
            RepositorioCliente.Create(Cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCliente.Delete(id);
        }

        public IEnumerable<Cliente> Listagem()
        {
            return RepositorioCliente.Read();
        }
    }
}
