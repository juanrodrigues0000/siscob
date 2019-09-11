using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {



        public ActionResult Index()
        {
            PagamentoDAO daoPgto = new PagamentoDAO();
            Pagamento pgto = new Pagamento();

            var Recebiveis = daoPgto.Listar().Count(x => x.Status != 1);
            var Pago = daoPgto.Listar().Count(x => x.Status == 1);

            return View(Recebiveis);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
