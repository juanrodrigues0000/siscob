using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO;

namespace WebApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            GravarComEntity();
        }

        private static void GravarComEntity()
        {
            Empresa empresa = new Empresa();
            EmpresaDAO adicionar = new EmpresaDAO();
            empresa.IdEmpresa = 123123;
            empresa.NomeEmpresa = "Benner";
            adicionar.Adicionar(empresa);
        }
    }
}