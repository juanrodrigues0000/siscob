namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Funcionario
    {
        public Funcionario()    
        {
           // this.Contrato1 = new HashSet<Contrato>();  // estava na classe contrato1
        }

        [Key]
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    
       // public virtual ICollection<Contrato> Contrato1 { get; set; }
    }
}
