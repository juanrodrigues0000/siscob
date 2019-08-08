﻿using siscob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class PagamentoDAO: IDisposable
    {
        public void Adicionar(Pagamento pagamento)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.PagamentoSet.Add(pagamento);
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
        public IList<Pagamento> Listar()
        {
            using (var contexto = new SiscobContext())
            {
                return contexto.PagamentoSet.ToList();
            }
        }
        public void Remover(Pagamento pagamento)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.PagamentoSet.Remove(pagamento);
                contexto.SaveChanges();
            }
        }

    }
}