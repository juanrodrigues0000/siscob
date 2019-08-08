using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Adicionar(string nome, string login, string senha, string funcao)
        {
            Funcionario funcionario = new Funcionario();
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.Funcao = funcao;

            dao.Adicionar(funcionario);

            return View();
        }

        public ActionResult Listar()
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            IList<Funcionario> funcionarios = dao.Listar();
            ViewBag.FuncionarioSet = funcionarios;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}