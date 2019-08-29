
namespace siscob
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public int SituacaoJuridica { get; set; }
        public int Categoria { get; set; }





    }
}