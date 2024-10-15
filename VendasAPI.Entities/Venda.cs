
    namespace VendasAPI.Domain.Entities
    {
        public class Venda
        {
            public int Id { get; set; }
            public DateTime DataVenda { get; set; }
            public string Cliente { get; set; }
            public decimal ValorTotal { get; set; }
            public string Filial { get; set; }
            public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
            public bool Cancelado { get; set; }
        }

        public class ItemVenda
        {
            public int ProdutoId { get; set; }
            public string ProdutoNome { get; set; }
            public decimal Quantidade { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal Desconto { get; set; }
            public decimal ValorTotal => (Quantidade * ValorUnitario) - Desconto;
        }
    }
    