using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using siscob;

namespace WebApplication1.DAO
{
    public class EmpresaDAO : IDisposable
    {
        {
        private SqlConnection conexao;

        public void ConexaoEmpresaDAO()
        {
       //     this.conexao = new SqlConnection(/////////////////);
       //     this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Empresa e)
        {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO empresas (IdEmpresa, NomeEmpresa) VALUES (@idEmpresa, @nomeEmpresa)";

                //Id precisa ser inserido automático

                var paramNome = new SqlParameter("nomeEmpresa", e.NomeEmpresa);
                insertCmd.Parameters.Add(paramNome);


                // Outros Atributos podem vir aqui


                insertCmd.ExecuteNonQuery();
        }

        internal void Atualizar(Empresa e)
        {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Empresas SET Nome = @nomeEmpresa WHERE IdEmpresa = @idEmpresa";

                var paramNome = new SqlParameter("nomeEmpresa", e.NomeEmpresa);
                //var paramId = new SqlParameter("idEmpresa", p.Id);

                updateCmd.Parameters.Add(paramNome);
                //updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

        }

        internal void Remover(Empresa e)
        {

                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Empresas WHERE IdEmpresa = @idEmpresa";

                var paramId = new SqlParameter("idEmpresa", e.IdEmpresa);
                deleteCmd.Parameters.Add(paramId);

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
