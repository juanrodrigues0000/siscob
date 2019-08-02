using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Adicionar(double valorIntegralDaParcela, double valorEmAberto, int contratoIdContrato,
                                        int clienteIdCliente)
        {
            Pagamento pagamento = new Pagamento();
            PagamentoDAO dao = new PagamentoDAO();
            pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
            pagamento.ValorEmAberto = valorEmAberto;
            pagamento.ContratoIdContrato = contratoIdContrato;
            pagamento.ClienteIdCliente = clienteIdCliente;

            dao.Adicionar(pagamento);

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}