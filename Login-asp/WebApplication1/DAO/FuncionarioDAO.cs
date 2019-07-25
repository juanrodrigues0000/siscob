using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using siscob;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.DAO
{
       public class FuncionarioDAO
       {
            public void Adicionar(Funcionario funcionario)
            {
                using (var contexto = new SiscobContext())
                {
                    contexto.Funcionarios.Add(funcionario);
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
            public IList<Funcionario> Funcionarios()
            {
                using (var contexto = new SiscobContext())
                {
                    return contexto.Funcionarios.ToList();
                }
            }
            public void Remover(Funcionario funcionario)
            {
                using (var contexto = new SiscobContext())
                {
                    contexto.Funcionarios.Remove(funcionario);
                    contexto.SaveChanges();
                }
            }
    }
}