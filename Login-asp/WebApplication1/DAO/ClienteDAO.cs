using Microsoft.EntityFrameworkCore;
using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class ClienteDAO: IDisposable
    {
        public void Adicionar(Cliente cliente)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.ClienteSet.Add(cliente);
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
        public IList<Cliente> Listar()
        {
            using (var contexto = new SiscobContext())
            {
                return contexto.ClienteSet.ToList();
            }
        }
        public void Remover(Cliente cliente)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.ClienteSet.Remove(cliente);
                contexto.SaveChanges();
            }
        }

        [HttpPost]
        public void Alterar(Cliente cliente)
        {

            using (var contexto = new SiscobContext())
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                contexto.SaveChanges();

                // contexto.ClienteSet.Attach(empresa);
                // contexto.SaveChanges();
            }
        }

    }
}