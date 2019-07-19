namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pagamento
    {
        public int IdPagamento { get; set; }
        public double ValorIntegralDaParcela { get; set; }
        public double ValorEmAberto { get; set; }
        public int ContratoIdContrato { get; set; }
        public int ClienteIdCliente { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
