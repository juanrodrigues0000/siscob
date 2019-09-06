using Microsoft.EntityFrameworkCore;
using siscob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class DocumentoDAO: IDisposable
    {

        public void Adicionar(Documento documento, string arquivo, HttpPostedFileBase arquivoConteudo)
        {
            using (var contexto = new SiscobContext())
            {
                var nomeDoArquivoFinal = "C:/Users/stag009/Desktop/Login-asp/WebApplication1/uploads/" + arquivoConteudo.FileName;
                var nomeArquivoPraSalvarNaTabela = "~/uploads/" + arquivoConteudo.FileName;
                arquivoConteudo.SaveAs(nomeDoArquivoFinal);
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