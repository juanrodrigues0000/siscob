namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Documento
    {

        [Key]
        public int IdDocumento { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
    
        public virtual Contrato Contrato { get; set; }
    }
}
