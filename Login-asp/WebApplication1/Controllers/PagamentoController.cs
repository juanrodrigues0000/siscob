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

        public ActionResult Listar()
        {
            PagamentoDAO dao = new PagamentoDAO();
            IList<Pagamento> pagamentos = dao.Listar();
            ViewBag.PagamentoSet = pagamentos;
            return View();
        }

        public ActionResult Remover(int idpagamento)
        {

            PagamentoDAO dao = new PagamentoDAO();
            var pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);
            dao.Remover(pagamento);
            return View();
        }


        [HttpPost]
        public ActionResult Alterar(int idpagamento)
        {
            PagamentoDAO dao = new PagamentoDAO();
            var pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);
            return View(pagamento);
        }

        [HttpPost]
        public ActionResult AlterarPagamento(int idpagamento, double valorIntegralDaParcela, double valorEmAberto, int contratoIdContrato,
                                        int clienteIdCliente)
        {

            PagamentoDAO dao = new PagamentoDAO();
            var pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);
            pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
            pagamento.ValorEmAberto = valorEmAberto;
            pagamento.ContratoIdContrato = contratoIdContrato;
            pagamento.ClienteIdCliente = clienteIdCliente;

            dao.Adicionar(pagamento);

            return View(pagamento);

        }

        public ActionResult Form()
        {
            return View();
        }
    }
}