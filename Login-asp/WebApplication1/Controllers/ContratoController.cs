using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Adicionar(string nomeTitular, double valorContrato, string garantia, int empresaIdEmpresa)
        {

            Contrato contrato = new Contrato();
            ContratoDAO dao = new ContratoDAO();
            contrato.NomeTitular = nomeTitular;
            contrato.ValorContrato = valorContrato;
            contrato.Garantia = garantia;
            contrato.EmpresaIdEmpresa = empresaIdEmpresa;
            //contrato.Empresa = empresa;

            dao.Adicionar(contrato);


            return View();
        }

        public ActionResult Listar()
        {
            ContratoDAO dao = new ContratoDAO();
            IList<Contrato> contratos = dao.Listar();
            ViewBag.ContratoSet = contratos;
            return View();
        }

        public ActionResult Remover(Contrato contrato)
        {

            ContratoDAO dao = new ContratoDAO();
            dao.Remover(contrato);
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}