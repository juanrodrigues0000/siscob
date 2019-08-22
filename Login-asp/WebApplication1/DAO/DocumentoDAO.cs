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
    public class DocumentoDAO: IDisposable
    {

        public void Adicionar(Documento documento)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.DocumentoSet.Add(documento);
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
        public IList<Documento> Listar()
        {
            using (var contexto = new SiscobContext())
            {
                return contexto.DocumentoSet.ToList();
            }
        }
        public void Remover(Documento documento)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.DocumentoSet.Remove(documento);
                contexto.SaveChanges();
            }
        }

        [HttpPost]
        public void Alterar(Documento documento)
        {

            using (var contexto = new SiscobContext())
            {

                contexto.Entry(documento).State = EntityState.Modified;
                contexto.SaveChanges();

                // contexto.EmpresaSet.Attach(empresa);
                // contexto.SaveChanges();
            }
        }
    }
}