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
            optionsBuilder.UseSqlServer("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\TesteDB.mdf;integrated security=True");
             }

    }
}
