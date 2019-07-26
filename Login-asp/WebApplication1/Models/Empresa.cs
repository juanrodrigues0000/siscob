namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Empresa
    {

        [Key]
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        public Empresa()
        {
            //this.Contrato = new HashSet<Contrato>();
        }

        //public virtual ICollection<Contrato> Contrato { get; set; }

    }
}
