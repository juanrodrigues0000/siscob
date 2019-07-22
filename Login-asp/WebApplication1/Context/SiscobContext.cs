using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Context
{
         public class SiscobContext : DbContext
        {
            protected void Onconfiguring (DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(StringDeConexao);
           }
        public const string StringDeConexao = "Server(localDB)MSSQLLocalDB;Databases=C:\\BENNER\\SISCOB\\NEW FOLDER\\SISCOB_ENTITY\\SISCOB\\TESTEDB.MDF";
       }
}