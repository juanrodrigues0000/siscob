using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Autentica(string login, string senha )
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            Funcionario funcionario = dao.Busca(login, senha);
            if (funcionario != null)
            {
                Session["funcionarioLogado"] = funcionario;
                return RedirectToAction("index","Form");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
    }
}