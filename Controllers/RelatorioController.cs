

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SistemaVenda.DAL;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Grafico()
        {
            var lista = mContext.VendaProdutos
                .GroupBy(x => x.CodigoProduto)
                .Select(y => new GraficoViewModel
                {
                    CodigoProduto = y.First().CodigoProduto,
                    Descricao = y.First().Produto.Descricao,
                    TotalVendidos = y.Sum(z => z.Quantidade)
                }).ToList();

            string valores = string.Empty;
            string labels = string.Empty;

            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendidos.ToString() + ",";
                labels += "'" + lista[i].Descricao.ToString() + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            return View();
        }
    }
}
