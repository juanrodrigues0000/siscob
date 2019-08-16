namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pagamento
    {
        [Key]
        public int IdPagamento { get; set; }
        public double ValorIntegralDaParcela { get; set; }
        public double ValorEmAberto { get; set; }
        public int ContratoIdContrato { get; set; }
        public int ClienteIdCliente { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Cliente Cliente { get; set; }



        public double CalculoContrato(double valorContrato, int quantidadeParcelas)
        {
            valorContrato *= 1.05;
            valorContrato = valorContrato / quantidadeParcelas;

            return valorContrato;

        }

    }

}
