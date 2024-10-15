
using VendasAPI.Domain.Entities;

namespace VendasAPI.Domain.Services
{
    public interface IVendaService
    {
        IEnumerable<Venda> GetAllVendas();
        Venda GetVendaById(int id);
        void AddVenda(Venda venda);
        void UpdateVenda(Venda venda);
        void DeleteVenda(int id);
    }
}
