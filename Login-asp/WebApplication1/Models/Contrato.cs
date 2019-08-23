namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Contrato
    {
        public Contrato() { }

        [Key]
        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public string NomeTitular { get; set; }
        public double ValorContrato { get; set; }
        public double ValorEmAberto { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime PrimeiroVencimento {get; set;}
        public string Garantia { get; set; }
        public int EmpresaIdEmpresa { get; set; }


    }
}

