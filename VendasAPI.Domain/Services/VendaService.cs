
using VendasAPI.Data.Repositories;
using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Events;

namespace VendasAPI.Domain.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public IEnumerable<Venda> GetAllVendas()
        {
            return _vendaRepository.GetAll();
        }

        public Venda GetVendaById(int id)
        {
            return _vendaRepository.GetById(id);
        }

        public void AddVenda(Venda venda)
        {
            _vendaRepository.Add(venda);

            // Log event for CompraCriada
            var compraCriadaEvent = new CompraCriadaEvent(venda.Id);
            compraCriadaEvent.LogEvent();
        }

        public void UpdateVenda(Venda venda)
        {
            _vendaRepository.Update(venda);

            // Log event for CompraAlterada
            var compraAlteradaEvent = new CompraAlteradaEvent(venda.Id);
            compraAlteradaEvent.LogEvent();
        }

        public void DeleteVenda(int id)
        {
            _vendaRepository.Delete(id);

            // Log event for CompraCancelada
            var compraCanceladaEvent = new CompraCanceladaEvent(id);
            compraCanceladaEvent.LogEvent();
        }
    }
}
