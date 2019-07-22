﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using siscob;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class DocumentoDAO : IDisposable
    {
        private SqlConnection conexao;

        public void ConexaoDocumentoDAO()
        {
            this.conexao = new SqlConnection(SiscobContext.StringDeConexao);
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Documento d)
        {
            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Documentos (Descricao, IdCliente) VALUES (@descricao, @idCliente)";

            //↑↑↑↑ removidos ID para serem inseridos automaticos

            var paramDescricao = new SqlParameter("descricao", d.Descricao);
            insertCmd.Parameters.Add(paramDescricao);

            var paramIdCliente = new SqlParameter("idCliente", d.IdCliente);
            insertCmd.Parameters.Add(paramIdCliente);

            insertCmd.ExecuteNonQuery();
        }

        internal void Atualizar(Documento d)
        {
            var updateCmd = conexao.CreateCommand();
            updateCmd.CommandText = "UPDATE Documentos SET Descricao = @Descricao, IdCliente = @idCliente  WHERE IdDocumento = @idDocumento";

            var paramDescricao = new SqlParameter("descricao", d.Descricao);
            updateCmd.Parameters.Add(paramDescricao);

            var paramIdCliente = new SqlParameter("idCliente", d.IdCliente);
            updateCmd.Parameters.Add(paramIdCliente);

            updateCmd.ExecuteNonQuery();

        }

        internal void Remover(Documento d)
        {

            var deleteCmd = conexao.CreateCommand();
            deleteCmd.CommandText = "DELETE FROM Documentos WHERE IdDocumento = @idDocumento";

            var paramDescricao = new SqlParameter("descricao", d.Descricao);
            deleteCmd.Parameters.Add(paramDescricao);

            var paramIdCliente = new SqlParameter("idCliente", d.IdCliente);
            deleteCmd.Parameters.Add(paramIdCliente);


            deleteCmd.ExecuteNonQuery();
        }

        internal IList<Documento> Documentos()
        {
            var lista = new List<Documento>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Documentos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Documento d = new Documento();
                d.IdDocumento = Convert.ToInt32(resultado["IdDocumento"]);
                d.Descricao = Convert.ToString(resultado["descricao"]);
                d.IdCliente = Convert.ToInt32(resultado["idCliente"]);

                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}