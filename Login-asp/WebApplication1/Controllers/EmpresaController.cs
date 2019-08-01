using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using siscob;
 

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

        public ActionResult Form()
        {
            return View();
        }
    }
}