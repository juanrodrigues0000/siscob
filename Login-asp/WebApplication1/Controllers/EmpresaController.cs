using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using siscob;
using WebApplication1.Context;


namespace WebApplication1.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Default
        
        public ActionResult Adicionar(string nomeEmpresa)
        {
            
            Empresa empresa = new Empresa();
            EmpresaDAO adicionar = new EmpresaDAO();
            empresa.NomeEmpresa = nomeEmpresa;
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

        [HttpPost]
        public ActionResult Alterar(int idempresa)
        {

                EmpresaDAO dao = new EmpresaDAO();
                var empresa = dao.Listar().FirstOrDefault(x => x.IdEmpresa == idempresa);
                dao.Alterar(empresa);
                return View(empresa);



            //]var empresa = dao.Listar().FirstOrDefault(x => x.IdEmpresa == idempresa);


           // var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();

        }


        public ActionResult Form()
        {
            return View();
        }
    }
}