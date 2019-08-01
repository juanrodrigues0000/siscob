using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public IList<Documento> Documentos()
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
    }
}