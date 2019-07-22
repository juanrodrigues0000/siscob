using siscob;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
    public class ContratoDAO
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

        internal void Adicionar(Contrato ct)
        {
            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Contratos (NomeTitular, ValorContrato, Garantia, EmpresaIdEmpresa, PagamentoIdPagamento, Empresa, Funcionario) " +
            "VALUES (@nomeTitular, @valorContrato, @garantia, @empresaIdEmpresa, @pagamentoIdPagamento, @empresa, @funcionario";

            
            //↑↑↑↑ removidos ID para serem inseridos automaticos 

            var paramNomeTitular = new SqlParameter("nomeTitular", ct.NomeTitular);
            insertCmd.Parameters.Add(paramNomeTitular);

            var paramValorContrato = new SqlParameter("valorContrato", ct.ValorContrato);
            insertCmd.Parameters.Add(paramValorContrato);

            var paramGarantia = new SqlParameter("cnpj", ct.Garantia);
            insertCmd.Parameters.Add(paramGarantia);

            var paramEmpresaIdEmpresa = new SqlParameter("endereco", ct.EmpresaIdEmpresa);
            insertCmd.Parameters.Add(paramEmpresaIdEmpresa);

            var paramEmpresa = new SqlParameter("empresa", ct.Empresa);
            insertCmd.Parameters.Add(paramEmpresa);

            var paramFuncionario = new SqlParameter("funcionario", ct.Funcionario);
            insertCmd.Parameters.Add(paramFuncionario);
          
            // FALTAM AS LISTAS DA CLASSE --CONTRATO--

            insertCmd.ExecuteNonQuery();
        }

        internal void Atualizar(Contrato ct)
        {
            var updateCmd = conexao.CreateCommand();
            updateCmd.CommandText = "UPDATE Contratos SET NomeTitular = @nomeTitular, ValorContrato = valorContrato, Garantia = garantia" +
            "EmpresaIdEmpresa = empresaIdEmpresa, PagamentoIdPagamento = @pagamentoIdPagamento, Empresa = @empresa, Funcionario = @funcionario" +
            " WHERE IdContrato = @idContrato";

            var paramNomeTitular = new SqlParameter("nomeTitular", ct.NomeTitular);
            updateCmd.Parameters.Add(paramNomeTitular);

            var paramValorContrato = new SqlParameter("valorContrato", ct.ValorContrato);
            updateCmd.Parameters.Add(paramValorContrato);

            var paramGarantia = new SqlParameter("cnpj", ct.Garantia);
            updateCmd.Parameters.Add(paramGarantia);

            var paramEmpresaIdEmpresa = new SqlParameter("endereco", ct.EmpresaIdEmpresa);
            updateCmd.Parameters.Add(paramEmpresaIdEmpresa);

            var paramEmpresa = new SqlParameter("empresa", ct.Empresa);
            updateCmd.Parameters.Add(paramEmpresa);

            var paramFuncionario = new SqlParameter("funcionario", ct.Funcionario);
            updateCmd.Parameters.Add(paramFuncionario);



            updateCmd.ExecuteNonQuery();

        }

        internal void Remover(Contrato ct)
        {

            var deleteCmd = conexao.CreateCommand();
            deleteCmd.CommandText = "DELETE FROM Contratos WHERE IdContrato = @idContrato";



            var paramNomeTitular = new SqlParameter("nomeTitular", ct.NomeTitular);
            deleteCmd.Parameters.Add(paramNomeTitular);

            var paramValorContrato = new SqlParameter("valorContrato", ct.ValorContrato);
            deleteCmd.Parameters.Add(paramValorContrato);

            var paramGarantia = new SqlParameter("cnpj", ct.Garantia);
            deleteCmd.Parameters.Add(paramGarantia);

            var paramEmpresaIdEmpresa = new SqlParameter("endereco", ct.EmpresaIdEmpresa);
            deleteCmd.Parameters.Add(paramEmpresaIdEmpresa);

            var paramEmpresa = new SqlParameter("empresa", ct.Empresa);
            deleteCmd.Parameters.Add(paramEmpresa);

            var paramFuncionario = new SqlParameter("funcionario", ct.Funcionario);
            deleteCmd.Parameters.Add(paramFuncionario);


            deleteCmd.ExecuteNonQuery();
        }

        internal IList<Contrato> Contratos()
        {
            var lista = new List<Contrato>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Contratos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Contrato ct = new Contrato();
                ct.IdContrato = Convert.ToInt32(resultado["idCliente"]);
                ct.NomeTitular = Convert.ToString(resultado["nomeTitular"]);
                ct.ValorContrato = Convert.ToDouble(resultado["valorContrato"]);
                ct.Garantia = Convert.ToString(resultado["garantia"]);
                ct.EmpresaIdEmpresa = Convert.ToInt16(resultado["empresaIdEmpresa"]);
                ct.Empresa = Convert.ToString(resultado["empresa"]);
                ct.Funcionario = Convert.ToString(resultado["funcionario"]);

                // FALTAM AS LISTS

                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}