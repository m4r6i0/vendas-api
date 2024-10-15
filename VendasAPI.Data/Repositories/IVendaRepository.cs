
using VendasAPI.Domain.Entities;

namespace VendasAPI.Data.Repositories
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> GetAll();
        Venda GetById(int id);
        void Add(Venda venda);
        void Update(Venda venda);
        void Delete(int id);
    }
}
