using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class ContratoDAO : IDisposable
    {
        public void Adicionar(Contrato contrato)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.ContratoSet.Add(contrato);
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
        public IList<Contrato> Contratos()
        {
            using (var contexto = new SiscobContext())
            {
                return contexto.ContratoSet.ToList();
            }
        }
        public void Remover(Contrato contrato)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.ContratoSet.Remove(contrato);
                contexto.SaveChanges();
            }
        }
    }
}