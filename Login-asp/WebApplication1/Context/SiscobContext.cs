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
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected void Onconfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog =C:\\BENNER\\SISCOB\\NEW FOLDER\\SISCOB_ENTITY\\SISCOB\\TESTEDB.MDF; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }

    }
}
