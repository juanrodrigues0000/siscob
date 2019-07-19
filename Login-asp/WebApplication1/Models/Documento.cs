namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
    
        public virtual Contrato Contrato { get; set; }
    }
}
