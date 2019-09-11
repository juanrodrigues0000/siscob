using siscob;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class ContratoController : Controller
    {

        double valorEmAberto = 0; // VARIÁVEL QUE SERÁ EDITADA PELA REGRA DE NEGÓCIO EM PAGAMENTO.CONTROLLER

        // GET: Contrato
        public ActionResult Adicionar(int idCliente, string nomeTitular, double valorContrato, int quantidadeParcelas, DateTime primeiroVencimento, string garantia, int empresaIdEmpresa)
        {


            Contrato contrato = new Contrato();
            ContratoDAO dao = new ContratoDAO();
            Cliente cliente = new Cliente();

            contrato.IdCliente = idCliente;
            contrato.NomeTitular = nomeTitular;
            contrato.ValorContrato = valorContrato;
            contrato.QuantidadeParcelas = quantidadeParcelas;
            contrato.PrimeiroVencimento = primeiroVencimento;
            contrato.Garantia = garantia;
            contrato.EmpresaIdEmpresa = empresaIdEmpresa;


            contrato.ValorEmAberto = valorEmAberto;

            dao.Adicionar(contrato);
            
            double auxiliarValorParcela = 0;                                // Usada para ALTERAR a entidade valorEmABerto na entidade CONTRATO depois 
                                                                        //que o método do método de valor de parcelas ter calculado o montante total

            double valorParcela;

            for (var i = 0; i < quantidadeParcelas; i++)
            {
                Pagamento pagamento = new Pagamento();

                valorParcela = pagamento.CalculoContrato(valorContrato, quantidadeParcelas);


                // INSERINDO NA TABELA PAGAMENTOS

                PagamentoDAO daoPagamento = new PagamentoDAO();
                pagamento.ValorIntegralDaParcela = valorParcela;
                pagamento.Status = 0;
                pagamento.IdContrato = contrato.IdContrato; 
                                        // ^ Metodo precisa vir depois de ADICIONAR CONTRATO, para que ele tenha uma ID pra ser registrada na table pagamentos
                pagamento.IdCliente = idCliente;
                // ^ Este dado não é pedido na entidade CONTRATO

                pagamento.DataVencimento = primeiroVencimento.AddMonths(i);
                daoPagamento.Adicionar(pagamento);

                auxiliarValorParcela = valorParcela * quantidadeParcelas;
            }

            contrato.ValorEmAberto = auxiliarValorParcela;

            dao.Alterar(contrato);

            return RedirectToAction("Form");

        }

        [HttpGet]
        public string CalculoMontante(double valorContrato, int quantidadeParcelas)
        {
            double resposta;

            Pagamento pagamento = new Pagamento();

            resposta = pagamento.CalculoContrato(valorContrato, quantidadeParcelas)* quantidadeParcelas;

            return resposta.ToString();

        }

        public ActionResult Listar()
        {
            ContratoDAO dao = new ContratoDAO();
            ViewBag.ContratoSet = dao.Listar();
            return View();
        }

        public ActionResult Remover(int idcontrato)
        {

            ContratoDAO dao = new ContratoDAO();
            var contrato = dao.Listar().FirstOrDefault(x => x.IdContrato == idcontrato);
            dao.Remover(contrato);

            return RedirectToAction("Listar");
        }

        public ActionResult Details(int idContrato)
        { 
            ContratoDAO dao = new ContratoDAO();
            PagamentoDAO daoPgto = new PagamentoDAO();
            ClienteDAO Cldao = new ClienteDAO();
            Cliente cliente = new Cliente();

            ViewBag.ClienteSet = dao.Listar().FirstOrDefault(X => X.IdContrato == idContrato);
            ViewBag.ContratoSet = dao.Listar().FirstOrDefault(x => x.IdContrato == idContrato);
            ViewBag.PagamentoSet = daoPgto.Listar().FirstOrDefault(x => x.IdContrato == idContrato);

            return View("Details");
        }


        public ActionResult Alterar(int idContrato)
        {
            ContratoDAO dao = new ContratoDAO();
            var contrato = dao.Listar().FirstOrDefault(x => x.IdContrato == idContrato);
            return View(contrato);
        }

        [HttpPost]
        public ActionResult AlteraContrato(int idContrato, string nomeTitular, double valorContrato, double valorEmAberto,
                                                                    int quantidadeParcelas, DateTime primeiroVencimento, string garantia, int empresaIdEmpresa)
        {

            ContratoDAO dao = new ContratoDAO();
            var contrato = dao.Listar().FirstOrDefault(x => x.IdContrato == idContrato);
            contrato.IdCliente = contrato.IdCliente;
            contrato.NomeTitular = nomeTitular;
            contrato.ValorContrato = valorContrato;
            contrato.ValorEmAberto = valorEmAberto;
            contrato.QuantidadeParcelas = quantidadeParcelas;
            contrato.PrimeiroVencimento = primeiroVencimento;
            contrato.Garantia = garantia;
            contrato.EmpresaIdEmpresa = empresaIdEmpresa;

            dao.Alterar(contrato);

            return View(contrato);

        }

        public ActionResult Pesquisa(int idContrato)
        {

            ContratoDAO dao = new ContratoDAO();
            IList<Contrato> ct = dao.Listar();
            var contrato = ct.Where(a => a.IdContrato == idContrato);
            ViewBag.ContratoSet = contrato;

            return View();

        }


        public ActionResult Form()
        {
            return View();
        }
    }
}