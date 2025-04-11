using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto Servico;
        public ServicoAplicacaoProduto(IServicoProduto servico) 
        { 
            Servico = servico;
        }

        public void Cadastrar(ProdutoViewModel ent)
        {
            Produto item = new Produto()
            {
                Codigo = ent.Codigo,
                Descricao = ent.Descricao,
                Quantidade = ent.Quantidade,
                Valor = (decimal)ent.Valor,
                CodigoCategoria = (int)ent.CodigoCategoria

            };

            Servico.Cadastrar(item);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var ent = Servico.CarregarRegistro(codigoProduto);
            ProdutoViewModel produto = new()
            {
                Codigo = ent.Codigo,
                Descricao = ent.Descricao,
                Quantidade = ent.Quantidade,
                Valor = (decimal)ent.Valor,
                CodigoCategoria = (int)ent.CodigoCategoria,
                DescricaoCategoria = ent.Categoria.Descricao
            };

            return produto;
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = Servico.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();

            foreach (var ent in lista) 
            {
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Codigo = ent.Codigo,
                    Descricao = ent.Descricao,
                    Quantidade = ent.Quantidade,
                    Valor = (decimal)ent.Valor,
                    CodigoCategoria = (int)ent.CodigoCategoria,
                    DescricaoCategoria = ent.Categoria.Descricao
                };

                listaProduto.Add(produto);

            }

            return listaProduto;
        }
    }
}
