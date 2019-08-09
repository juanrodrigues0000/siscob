using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Adicionar(string nomeCompleto, string cpf, string cnpj, string endereco, int situacaoJuridica, int categoria,
                                                       int associados, int clienteIdCliente)

        { 
            Cliente cliente = new Cliente();
            ClienteDAO dao = new ClienteDAO();
            cliente.NomeCompleto = nomeCompleto;
            cliente.CPF = cpf;
            cliente.CNPJ = cnpj;
            cliente.Endereco = endereco;
            cliente.SituacaoJuridica = situacaoJuridica;
            cliente.Categoria = categoria;
            cliente.Associados = associados;
            cliente.ClienteIdCliente = clienteIdCliente;

            dao.Adicionar(cliente);
                
            return View();
        }

        public ActionResult Listar()
        {
            ClienteDAO dao = new ClienteDAO();
            IList<Cliente> clientes = dao.Listar();
            ViewBag.ClienteSet = clientes;
            return View();
        }

        public ActionResult Remover(Cliente cliente)
        {

            ClienteDAO dao = new ClienteDAO();
            dao.Remover(cliente);
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}