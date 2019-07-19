namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato
    {
        public Contrato()
        {
            this.Documento = new HashSet<Documento>();
            this.Pagamento = new HashSet<Pagamento>();
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int IdContrato { get; set; }
        public string NomeTitular { get; set; }
        public double ValorContrato { get; set; }
        public string Garantia { get; set; }
        public int EmpresaIdEmpresa { get; set; }
        public int PagamentoIdPagamento { get; set; }
    
        public virtual ICollection<Documento> Documento { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual Funcionario Funcionario1 { get; set; }
    }
}
