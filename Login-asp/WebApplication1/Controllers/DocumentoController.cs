using siscob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using static WebApplication1.Models.UploadFileResult;

namespace WebApplication1.Controllers
{
    public class DocumentoController : Controller
    {
        // GET: Default
        public ActionResult Adicionar(string descricao, int idCliente, int idContrato /*byte[] arquivo Contrato contrato*/)
        {

            Documento documento = new Documento();
            DocumentoDAO doc = new DocumentoDAO();
            documento.Descricao = descricao;
            documento.IdCliente = idCliente;
            documento.Contrato_IdContrato = idContrato;



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
        public ActionResult Details(int idDocumento)
        {
            DocumentoDAO dao = new DocumentoDAO();
            ViewBag.DocumentoSet = dao.Listar().FirstOrDefault(x => x.IdDocumento == idDocumento);

            return View();
        }

        [HttpPost]
        public ActionResult Alterar(int iddocumento)
        {
            DocumentoDAO dao = new DocumentoDAO();
            var documento = dao.Listar().FirstOrDefault(x => x.IdDocumento == iddocumento);
            return View(documento);
        }

        [HttpPost]
        public ActionResult AlterarDocumento(int iddocumento, string descricao, int idCliente, int idContrato /*Contrato contrato*/)
        {

            DocumentoDAO dao = new DocumentoDAO();
            var documento = dao.Listar().FirstOrDefault(x => x.IdDocumento == iddocumento);
            documento.Descricao = descricao;
            documento.IdCliente = idCliente;
            documento.Contrato_IdContrato = idContrato;
            // byte []

            dao.Alterar(documento);
            return View(documento);
        }








    public ActionResult Form()
        {
            return View();
        }
    }
}