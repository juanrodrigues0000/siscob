//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Funcionario
    {
        public Funcionario()
        {
            this.Contrato1 = new HashSet<Contrato>();
        }
    
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string login { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    
        public virtual ICollection<Contrato> Contrato1 { get; set; }
    }
}
