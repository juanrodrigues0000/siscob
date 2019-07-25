namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa
    {

        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        public Empresa()
        {
            this.Contrato = new HashSet<Contrato>();
        }

        public virtual ICollection<Contrato> Contrato { get; set; }

    }
}
