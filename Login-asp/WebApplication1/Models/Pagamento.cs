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
        public int Status { get; set; }
        public DateTime DataVencimento { get; set; }
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

        public double CalculaJuroDiario(double valorIntegralParcela, double diasAtraso)
        {
            diasAtraso *= valorIntegralParcela * 0.01;

            valorIntegralParcela += diasAtraso;

            return valorIntegralParcela;
        }

    }

}
