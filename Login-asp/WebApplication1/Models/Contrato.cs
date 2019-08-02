namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Contrato
    {
        public Contrato()
        {
            this.Documentos = new HashSet<Documento>();
            this.Pagamentos = new HashSet<Pagamento>();
            this.Clientes = new HashSet<Cliente>();
        }

        [Key]
        public int IdContrato { get; set; }
        public string NomeTitular { get; set; }
        public double ValorContrato { get; set; }
        public string Garantia { get; set; }
        public int EmpresaIdEmpresa { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
