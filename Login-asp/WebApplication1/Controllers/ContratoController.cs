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
        // GET: Contrato
        public ActionResult Adicionar(string nomeTitular, double valorContrato, string garantia, int empresaIdEmpresa, int quantidadeParcelas, int idCliente)
        {

            Contrato contrato = new Contrato();
            ContratoDAO dao = new ContratoDAO();
            contrato.NomeTitular = nomeTitular;
            contrato.ValorContrato = valorContrato;
            contrato.Garantia = garantia;
            contrato.EmpresaIdEmpresa = empresaIdEmpresa;
            //contrato.Empresa = nomeEmpresa;


            dao.Adicionar(contrato);


           
            
            //int auxiliar;

            double valorParcela;

            Pagamento pagamento = new Pagamento();

            for (var i = 0; i < quantidadeParcelas; i++)
            {

                valorParcela = pagamento.CalculoContrato(valorContrato, quantidadeParcelas);


                // INSERINDO NA TABELA PAGAMENTOS

                if (i >= 1) { }



                PagamentoDAO daoPagamento = new PagamentoDAO();
                pagamento.ValorIntegralDaParcela = valorParcela;
                pagamento.ValorEmAberto = valorContrato;
                pagamento.ContratoIdContrato = contrato.IdContrato; 
                                        // ^ Metodo precisa vir depois de ADICIONAR CONTRATO, para que ele tenha uma ID pra ser registrada na table pagamentos
                pagamento.ClienteIdCliente = idCliente;
                                        // ^ Este dado não é pedido na entidade CONTRATO


                daoPagamento.Adicionar(pagamento);

                //auxiliar = pagamento.IdPagamento;
            }

            return View();

        }

        public ActionResult Listar()
        {
            ContratoDAO dao = new ContratoDAO();
            IList<Contrato> contratos = dao.Listar();
            ViewBag.ContratoSet = contratos;
            return View();
        }

        public ActionResult Remover(int idcontrato)
        {

            ContratoDAO dao = new ContratoDAO();
            var contrato = dao.Listar().FirstOrDefault(x => x.IdContrato == idcontrato);
            dao.Remover(contrato);
            return View();
        }


        public ActionResult Form()
        {
            return View();
        }
    }
}