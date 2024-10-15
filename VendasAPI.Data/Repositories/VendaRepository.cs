
using VendasAPI.Domain.Entities;
using System.Collections.Generic;

namespace VendasAPI.Data.Repositories
{
   
    public class VendaRepository : IVendaRepository
    {
        private readonly List<Venda> vendas = new List<Venda>();

        public IEnumerable<Venda> GetAll()
        {
            return vendas;
        }

        public Venda GetById(int id)
        {
            return vendas.Find(v => v.Id == id);
        }

        public void Add(Venda venda)
        {
            vendas.Add(venda);
        }

        public void Update(Venda venda)
        {
            var index = vendas.FindIndex(v => v.Id == venda.Id);
            if (index != -1)
            {
                vendas[index] = venda;
            }
        }

        public void Delete(int id)
        {
            vendas.RemoveAll(v => v.Id == id);
        }
    }
}
