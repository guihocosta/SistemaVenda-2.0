using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        protected ApplicationDbContext mContext;

        public VendaController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Venda> lista = mContext.Venda.ToList(); // Método caro, evitar
            mContext.Dispose();
            return View(lista);
        }

        private IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });

            }

            return lista;

        }

        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in mContext.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome.ToString()
                });

            }

            return lista;

        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaProdutos = ListaProdutos();
            viewModel.ListaClientes = ListaClientes();

            if (id != null)
            {
                var entidade = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault(); // Primeiro que aparece
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.CodigoCliente = entidade.CodigoCliente;
                viewModel.Total = entidade.Total;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Venda objVenda = new Venda()
                {
                    Codigo = entidade.Codigo,
                    Data = (DateTime)entidade.Data,
                    CodigoCliente = (int)entidade.CodigoCliente,
                    Total = entidade.Total,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(entidade.JsonProdutos)
                };

                if (entidade.Codigo == null)
                {
                    mContext.Venda.Add(objVenda);
                }
                else
                {
                    mContext.Entry(objVenda).State = EntityState.Modified;
                }

                mContext.SaveChanges();

            }
            else
            {
                entidade.ListaProdutos = ListaProdutos();
                entidade.ListaProdutos = ListaProdutos();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Produto() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
