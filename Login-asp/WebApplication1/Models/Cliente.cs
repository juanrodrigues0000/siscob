
namespace siscob
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Contrato = new HashSet<Contrato>();
            this.Pagamento = new HashSet<Pagamento>();
            this.Cliente2 = new HashSet<Cliente>();
        }
    
        public int IdCliente { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public int SituacaoJuridica { get; set; }
        public int Categoria { get; set; }
        public int Associados { get; set; }
        public int ClienteIdCliente { get; set; }
    
        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Cliente> Cliente2 { get; set; }
        public virtual Cliente Cliente1 { get; set; }
    }
}
