using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using siscob;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
       public class FuncionarioDAO: IDisposable
       {
            public void Adicionar(Funcionario funcionario)
            {
                using (var contexto = new SiscobContext())
                {
                    contexto.FuncionarioSet.Add(funcionario);
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
            public IList<Funcionario> Listar()
        {
                using (var contexto = new SiscobContext())
                {
                    return contexto.FuncionarioSet.ToList();
                }
            }
            public void Remover(Funcionario funcionario)
            {
                using (var contexto = new SiscobContext())
                {
                    contexto.FuncionarioSet.Remove(funcionario);
                    contexto.SaveChanges();
                }
            }
      

            public Funcionario Busca(string login, string senha) // método para verificar a senha do funcionário que tenta logar
            {
                using (var contexto = new SiscobContext())
                {
                    return contexto.FuncionarioSet.FirstOrDefault(u => u.Login == login && u.Senha == senha);
                }
            }

        
       }
}