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

        int pagamentoDeferido = 0;

        // GET: Pagamento
        public ActionResult Adicionar(double valorIntegralDaParcela, DateTime dataVencimento, int contratoIdContrato,
                                        int clienteIdCliente)
        {
            Pagamento pagamento = new Pagamento();
            PagamentoDAO dao = new PagamentoDAO();
            pagamento.ValorIntegralDaParcela = valorIntegralDaParcela;
            pagamento.Status = pagamentoDeferido;
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
        public ActionResult AlterarPagamento(int idpagamento, double valorIntegralDaParcela, int status, DateTime dataVencimento, int contratoIdContrato,
                                        int clienteIdCliente)
        {
            PagamentoDAO dao = new PagamentoDAO();
            var pagamento = dao.Listar().FirstOrDefault(x => x.IdPagamento == idpagamento);
            
            ContratoDAO CtDao = new ContratoDAO();
            var contrato = new Contrato();


            pagamento.Status = 1; // STATUS DE RECEBIMENTO
            contrato.ValorEmAberto -= valorPago;

            /*
            var dataAtual = DateTime.Now;
            var outraData = new DateTime(2019, 02, 12);
            var diferenca = dataAtual - outraData;
            */

            if (valorPago < valorIntegralDaParcela)
            {
                var proximoPagamento = dao.BuscarProximoPagamento(pagamento);
                if(proximoPagamento == null)
                {
                    dao.Adicionar()
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

        public ActionResult Form()
        {
            return View();
        }
    }
}