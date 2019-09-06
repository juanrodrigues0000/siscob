using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using siscob;

namespace WebApplication1.Context
{
    public class SiscobContext : DbContext, IDisposable
    {
        public DbSet<Empresa> EmpresaSet { get; set; }
        public DbSet<Funcionario> FuncionarioSet { get; set; }
        public DbSet<Documento> DocumentoSet { get; set; }
        public DbSet<Cliente> ClienteSet { get; set; }
        public DbSet<Pagamento> PagamentoSet { get; set; }
        public DbSet<Contrato> ContratoSet { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AgoraDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }


    }
}
