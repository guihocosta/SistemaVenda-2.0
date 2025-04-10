using Aplicacao.Servico.Interfaces;
using Aplicacao.Servicos.Interfaces;
using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente ServicoCliente;
        public ServicoAplicacaoCliente(IServicoCliente servicoCliente) 
        { 
            ServicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel Cliente)
        {
            Cliente ent = new Cliente()
            {
                Codigo = Cliente.Codigo,
                Nome = Cliente.Nome,
                CNPJ_CPF = Cliente.CNPJ_CPF,
                Email = Cliente.Email,
                Celular = Cliente.Celular
            };

            ServicoCliente.Cadastrar(ent);
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var registro = ServicoCliente.CarregarRegistro(codigoCliente);
            ClienteViewModel Cliente = new ClienteViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Email = registro.Email,
                Celular = registro.Celular
            };
            return Cliente;
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = ServicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista) 
            {
                ClienteViewModel Cliente = new ClienteViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Email = item.Email,
                    Celular = item.Celular
                };

                listaCliente.Add(Cliente);

            }

            return listaCliente;
        }
    }
}
