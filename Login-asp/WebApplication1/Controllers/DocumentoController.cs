using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class DocumentoController : Controller
    {
        // GET: Default
        public ActionResult Adicionar(string descricao, int idCliente, Contrato contrato)
        {

            Documento documento = new Documento();
            DocumentoDAO doc = new DocumentoDAO();
            documento.Descricao = descricao;
            documento.IdCliente = idCliente;
            //id Contrato
            // byte []

            doc.Adicionar(documento);

            return View();
        }

        public ActionResult Listar()
        {
            DocumentoDAO dao = new DocumentoDAO();
            IList<Documento> documentos = dao.Listar();
            ViewBag.DocumentoSet = documentos;
            return View();
        }

        public ActionResult Remover(int iddocumento)
        {

            DocumentoDAO dao = new DocumentoDAO();
            var documento = dao.Listar().FirstOrDefault(x => x.IdDocumento == iddocumento);
            dao.Remover(documento);
            return View();
        }



        public ActionResult Form()
        {
            return View();
        }
    }
}