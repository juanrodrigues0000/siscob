﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using siscob;
using WebApplication1.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DAO
{
    public class EmpresaDAO : IDisposable
    {

        public void Adicionar(Empresa empresa)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.EmpresaSet.Add(empresa);
                contexto.SaveChanges();
            }
        }
        public void Dispose()
        {
            using (var contexto = new SiscobContext())
            {
                contexto.Dispose();
            }
        }
        public IList<Empresa> Empresas()
        {
            using (var contexto = new SiscobContext())
            {
                return contexto.EmpresaSet.ToList();
            }
        }
        public void Remover(Empresa empresa)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.EmpresaSet.Remove(empresa);
                contexto.SaveChanges();
            }
        }
    }
}
