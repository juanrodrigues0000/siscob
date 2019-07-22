using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using siscob;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class ClienteDAO
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

            internal void Adicionar(Cliente c)
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Clientes (IdCliente, NomeCompleto, CPF, CNPJ, Endereco, SituacaoJuridica, Categoria, Associados, ClienteIdCliente) " +
                "VALUES (@idCliente, @nomeCompleto, @cpf, @cnpj, @endereco, @situacaoJuridica, @categoria, @associados, @clienteIdCliente)";



                 //↑↑↑↑ removidos ID para serem inseridos automaticos

                var paramNomeCompleto = new SqlParameter("nomeCompleto", c.NomeCompleto);
                insertCmd.Parameters.Add(paramNomeCompleto);

                var paramCPF = new SqlParameter("cpf", c.CPF);
                insertCmd.Parameters.Add(paramCPF);

                var paramCNPJ = new SqlParameter("cnpj", c.CNPJ);
                insertCmd.Parameters.Add(paramCNPJ);

                var paramEndereco = new SqlParameter("endereco", c.Endereco);
                insertCmd.Parameters.Add(paramEndereco);

                var paramSituacaoJuridica = new SqlParameter("situacaoJuridica", c.SituacaoJuridica);
                insertCmd.Parameters.Add(paramSituacaoJuridica);

                var paramCategoria = new SqlParameter("categoria", c.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                var paramAssociados = new SqlParameter("associados", c.Associados);
                insertCmd.Parameters.Add(paramAssociados);

                var paramClienteIdCliente = new SqlParameter("clienteIdCliente", c.ClienteIdCliente);
                insertCmd.Parameters.Add(paramClienteIdCliente);

            insertCmd.ExecuteNonQuery();
            }

            internal void Atualizar(Cliente c)
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Documentos SET NomeCompleto = @nomeCompleto, CPF = @cpf, CNPJ = @cnpj, " +
                "Endereco = @endereco, SituacaoJuridica = @situacaoJuridica, Categoria = @categoria, Associados = @associados, ClienteIdCliente = @clienteIdCliente" +
                " WHERE IdCliente = @idCliente";



                var paramNomeCompleto = new SqlParameter("nomeCompleto", c.NomeCompleto);
                updateCmd.Parameters.Add(paramNomeCompleto);

                var paramCPF = new SqlParameter("cpf", c.CPF);
                updateCmd.Parameters.Add(paramCPF);

                var paramCNPJ = new SqlParameter("cnpj", c.CNPJ);
                updateCmd.Parameters.Add(paramCNPJ);

                var paramEndereco = new SqlParameter("endereco", c.Endereco);
                updateCmd.Parameters.Add(paramEndereco);

                var paramSituacaoJuridica = new SqlParameter("situacaoJuridica", c.SituacaoJuridica);
                updateCmd.Parameters.Add(paramSituacaoJuridica);

                var paramAssociados = new SqlParameter("associados", c.Associados);
                updateCmd.Parameters.Add(paramAssociados);

                var paramClienteIdCliente = new SqlParameter("clienteIdCliente", c.ClienteIdCliente);
                updateCmd.Parameters.Add(paramClienteIdCliente);

            updateCmd.ExecuteNonQuery();

            }

            internal void Remover(Cliente c)
            {

                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Clientes WHERE IdCliente = @idCliente";

            var paramNomeCompleto = new SqlParameter("nomeCompleto", c.NomeCompleto);
            deleteCmd.Parameters.Add(paramNomeCompleto);

            var paramCPF = new SqlParameter("cpf", c.CPF);
            deleteCmd.Parameters.Add(paramCPF);

            var paramCNPJ = new SqlParameter("cnpj", c.CNPJ);
            deleteCmd.Parameters.Add(paramCNPJ);

            var paramEndereco = new SqlParameter("endereco", c.Endereco);
            deleteCmd.Parameters.Add(paramEndereco);

            var paramSituacaoJuridica = new SqlParameter("situacaoJuridica", c.SituacaoJuridica);
            deleteCmd.Parameters.Add(paramSituacaoJuridica);

            var paramAssociados = new SqlParameter("associados", c.Associados);
            deleteCmd.Parameters.Add(paramAssociados);

            var paramClienteIdCliente = new SqlParameter("clienteIdCliente", c.ClienteIdCliente);
            deleteCmd.Parameters.Add(paramClienteIdCliente);

            deleteCmd.ExecuteNonQuery();
            }

            internal IList<Cliente> Clientes()
            {
                var lista = new List<Cliente>();

                var selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Clientes";

                var resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                Cliente c = new Cliente();
                    c.IdCliente = Convert.ToInt32(resultado["idCliente"]);
                    c.NomeCompleto = Convert.ToString(resultado["nomeCompleto"]);
                    c.CPF = Convert.ToString(resultado["cpf"]);
                    c.CNPJ = Convert.ToString(resultado["cnpj"]);
                    c.Endereco = Convert.ToString(resultado["endereco"]);
                    c.SituacaoJuridica = Convert.ToInt16(resultado["situacaoJuridica"]);
                    c.Associados = Convert.ToInt16(resultado["associados"]);
                    c.ClienteIdCliente = Convert.ToInt32(resultado["clienteIdCliente"]);
                    

                    lista.Add(p);
                }
                resultado.Close();

                return lista;
            }
    }
}