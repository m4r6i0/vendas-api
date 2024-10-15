
namespace VendasAPI.Domain.Events
{
    public class CompraCriadaEvent
    {
        public int CompraId { get; set; }
        public DateTime DataCriacao { get; set; }

        public CompraCriadaEvent(int compraId)
        {
            CompraId = compraId;
            DataCriacao = DateTime.Now;
        }

        public void LogEvent()
        {
            Console.WriteLine($"CompraCriadaEvent: Compra {CompraId} criada em {DataCriacao}");
        }
    }

    public class CompraAlteradaEvent
    {
        public int CompraId { get; set; }
        public DateTime DataAlteracao { get; set; }

        public CompraAlteradaEvent(int compraId)
        {
            CompraId = compraId;
            DataAlteracao = DateTime.Now;
        }

        public void LogEvent()
        {
            Console.WriteLine($"CompraAlteradaEvent: Compra {CompraId} alterada em {DataAlteracao}");
        }
    }

    public class CompraCanceladaEvent
    {
        public int CompraId { get; set; }
        public DateTime DataCancelamento { get; set; }

        public CompraCanceladaEvent(int compraId)
        {
            CompraId = compraId;
            DataCancelamento = DateTime.Now;
        }

        public void LogEvent()
        {
            Console.WriteLine($"CompraCanceladaEvent: Compra {CompraId} cancelada em {DataCancelamento}");
        }
    }

    public class ItemCanceladoEvent
    {
        public int ItemId { get; set; }
        public DateTime DataCancelamento { get; set; }

        public ItemCanceladoEvent(int itemId)
        {
            ItemId = itemId;
            DataCancelamento = DateTime.Now;
        }

        public void LogEvent()
        {
            Console.WriteLine($"ItemCanceladoEvent: Item {ItemId} cancelado em {DataCancelamento}");
        }
    }
}
