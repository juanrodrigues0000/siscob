using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using siscob;
using WebApplication1.Context;
using WebApplication1.Filtros;

namespace WebApplication1.Controllers
{
    // [AutorizacaoFilter]
    public class EmpresaController : Controller
    {
        // GET: Default
        
        public ActionResult Adicionar(string nomeEmpresa, int teleFoneEmpresa, string enderecoEmpresa)
        {
            
            Empresa empresa = new Empresa();
            EmpresaDAO adicionar = new EmpresaDAO();
            empresa.NomeEmpresa = nomeEmpresa;
            empresa.TelefoneEmpresa = teleFoneEmpresa;
            empresa.EnderecoEmpresa = enderecoEmpresa;
            adicionar.Adicionar(empresa);

            return View();
        }

        public ActionResult Listar()
        {
            EmpresaDAO dao = new EmpresaDAO();
            IList<Empresa> empresas = dao.Listar();
            ViewBag.EmpresaSet = empresas;
            return View();
        }

        public ActionResult Remover(int idempresa)
        {
           EmpresaDAO dao = new EmpresaDAO();
           var empresa = dao.Listar().FirstOrDefault(x => x.IdEmpresa == idempresa);
           dao.Remover(empresa);
           return View();
        }

        public ActionResult Details(int idEmpresa)
        {
            EmpresaDAO dao = new EmpresaDAO();

            ViewBag.EmpresaSet = dao.Listar().FirstOrDefault(x => x.IdEmpresa == idEmpresa);

            return View();
        }

        [HttpPost]
        public ActionResult Alterar(int IdEmpresa, string NomeEmpresa)
        {
            EmpresaDAO dao = new EmpresaDAO();
            var empresa = dao.Listar().FirstOrDefault(x => x.IdEmpresa == IdEmpresa);
            return View(empresa);
        }

        [HttpPost]
        public ActionResult AlterarEmpresa(int IdEmpresa, string NomeEmpresa, int telefoneEmpresa, string enderecoEmpresa)
        {

            EmpresaDAO dao = new EmpresaDAO();
            var empresa = dao.Listar().FirstOrDefault(x => x.IdEmpresa == IdEmpresa);
            empresa.NomeEmpresa = NomeEmpresa;
            empresa.TelefoneEmpresa = telefoneEmpresa;
            empresa.EnderecoEmpresa = enderecoEmpresa;
            dao.Alterar(empresa);
            return View(empresa);

        }


        public ActionResult Pesquisa(string nomeEmpresa)
        {

            EmpresaDAO dao = new EmpresaDAO();
            IList<Empresa> empresa = dao.Listar();
            var Empresa = empresa.Where(a => a.NomeEmpresa.ToLower().Contains(nomeEmpresa.ToLower()));
            ViewBag.EmpresaSet = Empresa;

            return View();

        }

        public ActionResult Form()
        {
            return View();
        }
    }
}