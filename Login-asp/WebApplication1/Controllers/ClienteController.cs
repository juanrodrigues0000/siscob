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
        public ActionResult Adicionar(string nomeCompleto, string cpf, string cnpj, string endereco, int telefone, int situacaoJuridica, int categoria)

        { 
            Cliente cliente = new Cliente();
            ClienteDAO dao = new ClienteDAO();
            cliente.NomeCompleto = nomeCompleto;
            cliente.CPF = cpf;
            cliente.CNPJ = cnpj;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
            cliente.SituacaoJuridica = situacaoJuridica;
            cliente.Categoria = categoria;
 

            dao.Adicionar(cliente);
                
            return View("Form");
        }

        public ActionResult Listar()
        {
            ClienteDAO dao = new ClienteDAO();
            IList<Cliente> clientes = dao.Listar();
            ViewBag.ClienteSet = clientes;
            return View();
        }

        public ActionResult Remover(int idcliente)
        {

            ClienteDAO dao = new ClienteDAO();
            var cliente = dao.Listar().FirstOrDefault(x => x.IdCliente == idcliente);
            dao.Remover(cliente);
            return View("Listar");
        }

        public ActionResult Details(int idcliente)
        {
            ClienteDAO dao = new ClienteDAO();
            ViewBag.ClienteSet = dao.Listar().FirstOrDefault(x => x.IdCliente == idcliente);

            return View();
        }

        [HttpPost]
        public ActionResult Alterar(int idCliente)
        {

            ClienteDAO dao = new ClienteDAO();
            var cliente = dao.Listar().FirstOrDefault(x => x.IdCliente == idCliente);
            dao.Alterar(cliente);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult AlterarCliente(int idCliente, string nomeCompleto, string cpf, string cnpj,
                                                    string endereco, int telefone, int situacaoJuridica, int categoria)
        {

            ClienteDAO dao = new ClienteDAO();
            var cliente = dao.Listar().FirstOrDefault(x => x.IdCliente == idCliente);
            cliente.NomeCompleto = nomeCompleto;
            cliente.CPF = cpf;
            cliente.CNPJ = cnpj;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
            cliente.SituacaoJuridica = situacaoJuridica;
            cliente.Categoria = categoria;


            dao.Alterar(cliente);

            return RedirectToAction("Listar");

        }


        public ActionResult Pesquisa(string nome)
        {

            ClienteDAO dao = new ClienteDAO();
            IList<Cliente> cl = dao.Listar();
                var cliente = cl.Where(a => a.NomeCompleto.ToLower().Contains(nome.ToLower()));
                ViewBag.ClienteSet = cliente;

                return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}