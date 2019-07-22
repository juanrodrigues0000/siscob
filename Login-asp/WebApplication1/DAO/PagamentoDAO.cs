using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using siscob;

namespace WebApplication1.DAO
{
    public class PagamentoDAO
    {
        private SqlConnection conexao;

        public void ConexaoEmpresaDAO()
        {
            this.conexao = new SqlConnection(SiscobContext.StringDeConexao);
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Pagamento pg)
        {
            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Pagamentos () VALUES (@nomeEmpresa)";

            //↑↑↑↑ removidos ID para serem inseridos automaticos

            var paramNomeEmpresa = new SqlParameter("nomeEmpresa", e.NomeEmpresa);
            insertCmd.Parameters.Add(paramNomeEmpresa);

            insertCmd.ExecuteNonQuery();
        }

        internal void Atualizar(Empresa e)
        {
            var updateCmd = conexao.CreateCommand();
            updateCmd.CommandText = "UPDATE Empresas SET Nome = @nomeEmpresa WHERE IdEmpresa = @idEmpresa";

            var paramNomeEmpresa = new SqlParameter("nomeEmpresa", e.NomeEmpresa);

            updateCmd.Parameters.Add(paramNomeEmpresa);

            updateCmd.ExecuteNonQuery();

        }

        internal void Remover(Empresa e)
        {

            var deleteCmd = conexao.CreateCommand();
            deleteCmd.CommandText = "DELETE FROM Empresas WHERE IdEmpresa = @idEmpresa";

            var paramNomeEmpresa = new SqlParameter("idEmpresa", e.NomeEmpresa);
            deleteCmd.Parameters.Add(paramNomeEmpresa);

            deleteCmd.ExecuteNonQuery();
        }

        internal IList<Empresa> Empresas()
        {
            var lista = new List<Empresa>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Empresas";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Empresa e = new Empresa();
                p.IdEmpresa = Convert.ToInt32(resultado["IdEmpresa"]);
                p.NomeEmpresa = Convert.ToString(resultado["nomeEmpresa"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}