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
        public ActionResult Adicionar(double valorIntegralDaParcela, DateTime dataVencimento, int contratoIdContrato,
                                        int clienteIdCliente)
        {
            Pagamento pagamento = new Pagamento();
            PagamentoDAO dao = new PagamentoDAO();
            pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
            pagamento.Status = 0;
            pagamento.DataVencimento = dataVencimento;
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
            return RedirectToAction("Listar", "Pagamento");
        }

        public ActionResult Details(int idPagamento)
        {
            PagamentoDAO dao = new PagamentoDAO();
            ContratoDAO daoContrato = new ContratoDAO();

            ViewBag.PagamentoSet = dao.Listar().FirstOrDefault(x => x.IdPagamento == idPagamento);

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
        public ActionResult AlterarPagamento(int idpagamento, double valorIntegralDaParcela, int status, DateTime dataVencimento, double valorPago, int contratoIdContrato, 
                                        int clienteIdCliente)
        {

            
            PagamentoDAO dao = new PagamentoDAO();
            Pagamento pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);
            
            ContratoDAO CtDao = new ContratoDAO();
            var contrato = new Contrato();


            pagamento.Status = 1; // STATUS DE RECEBIMENTO
            
            var dataAtual = DateTime.Now;
            var outraData = pagamento.DataVencimento;

            TimeSpan Atraso = dataAtual.Subtract(outraData);

            double diasDeAtraso = Atraso.TotalDays;


            var novoValorPagamento = pagamento.CalculaJuroDiario(valorIntegralDaParcela, diasDeAtraso);

            if (valorPago < valorIntegralDaParcela)
            {
                var proximoPagamento = dao.BuscarProximoPagamento(pagamento);
                if (proximoPagamento == null)
                {
                    pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
                    pagamento.Status = status;
                    pagamento.DataVencimento = dataVencimento;
                    pagamento.ContratoIdContrato = contratoIdContrato;
                    pagamento.ClienteIdCliente = clienteIdCliente;

                    dao.Adicionar(pagamento);
                }
            }

            pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
            pagamento.Status = status;
            pagamento.DataVencimento = dataVencimento;
            pagamento.ContratoIdContrato = contratoIdContrato;
            pagamento.ClienteIdCliente = clienteIdCliente;

            dao.Alterar(pagamento);

            return View(pagamento);

        }

        public ActionResult Quitar(int idpagamento)
        {
            PagamentoDAO dao = new PagamentoDAO();
            Pagamento pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);

            double pgtoRealizado = 0;

            pagamento.ValorIntegralDaParcela = pgtoRealizado;
            pagamento.Status = 1;
            pagamento.DataVencimento = pagamento.DataVencimento;
            pagamento.ContratoIdContrato = pagamento.ContratoIdContrato;
            pagamento.ClienteIdCliente = pagamento.ClienteIdCliente;

            dao.Alterar(pagamento);

            return View(pagamento);
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}