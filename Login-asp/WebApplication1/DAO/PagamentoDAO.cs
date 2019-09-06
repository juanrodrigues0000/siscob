using Microsoft.EntityFrameworkCore;
using siscob;
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

        public void Alterar(Pagamento pagamento)
        {
            using (var contexto = new SiscobContext())
            {
                contexto.Entry(pagamento).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Pagamento BuscarProximoPagamento(Pagamento pagamentoAtual)
        {
            using (var contexto = new SiscobContext())
            {
                var resultado = contexto.PagamentoSet
                    .Where(x => x.DataVencimento > pagamentoAtual.DataVencimento && x.IdContrato == pagamentoAtual.IdContrato)
                    .OrderBy(x => x.DataVencimento)
                    .FirstOrDefault();
                return resultado;
            }
        }

        public IList<Pagamento> PagamentosEmAtraso()
        {
            var dataAtual = DateTime.Now;
            using (var contexto = new SiscobContext())
            {
                var resultado = contexto.PagamentoSet
                    .Where(x => x.DataVencimento < dataAtual && x.Status == 0);
                return resultado.ToList();
            }
        }
        public IList<Pagamento> PagamentosPendentesFuturos()
        {
            var dataAtual = DateTime.Now;
            using (var contexto = new SiscobContext())
            {
                var resultado = contexto.PagamentoSet
                    .Where(x => x.DataVencimento >= dataAtual && x.DataVencimento <= dataAtual.AddDays(7) && x.Status == 0);
                return resultado.ToList();
            }
        }

    }
}