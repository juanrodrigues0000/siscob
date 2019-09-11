using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
    [AutorizacaoFilter]
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
        //[Route("Funcionario/Remover/{idfuncionario:int}")]
        public ActionResult Remover(int idfuncionario)
        {
            
            FuncionarioDAO dao = new FuncionarioDAO();
            var funcionario = dao.Listar().FirstOrDefault(x => x.IdFuncionario == idfuncionario);
            dao.Remover(funcionario);
            return View();
        }

        public ActionResult Details(int idFuncionario)
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            ViewBag.FuncionarioSet = dao.Listar().FirstOrDefault(x => x.IdFuncionario == idFuncionario);

            return View();
        }


        [HttpPost]
        public ActionResult Alterar(int IdFuncionario, string nome, string login, string senha, string funcao)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            var funcionario = dao.Listar().FirstOrDefault(x => x.IdFuncionario == IdFuncionario);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult AlterarFuncionario(int IdFuncionario, string nome, string login, string senha, string funcao)
        {

            FuncionarioDAO dao = new FuncionarioDAO();
            var funcionario = dao.Listar().FirstOrDefault(x => x.IdFuncionario == IdFuncionario);
            funcionario.Nome = nome;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.Funcao = funcao;

            dao.Alterar(funcionario);

            return View("Listar");

        }

        public ActionResult Pesquisa(string nomeFuncionario)
        {

            FuncionarioDAO dao = new FuncionarioDAO();
            IList<Funcionario> funcionario = dao.Listar();
            var Funcionario = funcionario.Where(a => a.Nome.ToLower().Contains(nomeFuncionario.ToLower()));
            ViewBag.FuncionarioSet = Funcionario;

            return View();

        }

        public ActionResult Form()
        {
            return View();
        }
    }
}