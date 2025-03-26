using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {

        protected ApplicationDbContext mContext;
        IHttpContextAccessor HttpContextAcessor;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            mContext = context;
            HttpContextAcessor = httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {

            ViewData["ErroLogin"] = string.Empty;

            if (ModelState.IsValid)
            {

                var usuario = mContext.Usuario.Where(x => x.Email == model.Email && x.Senha == model.Senha).FirstOrDefault();
                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "O Email ou Senha informado não existe no Sistema!";
                    return View(model);
                }
                else
                {
                    // Dados na Sessão
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    HttpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    HttpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }  
        }

        [HttpGet]
        public IActionResult Index(int? id) 
        {
            if (id != null)
            {
                if(id == 0)
                {
                    HttpContextAcessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }


    }
}
