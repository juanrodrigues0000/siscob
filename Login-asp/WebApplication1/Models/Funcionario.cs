namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Funcionario
    {
        public Funcionario()    
        {
            this.Contrato1 = new HashSet<Contrato>();  // estava na classe contrato1
        }
    
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string login { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    
        public virtual ICollection<Contrato> Contrato1 { get; set; }
    }
}
