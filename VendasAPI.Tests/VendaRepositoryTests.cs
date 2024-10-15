using VendasAPI.Domain.Services;
using NSubstitute;
using Bogus;
using VendasAPI.Data.Repositories;
using VendasAPI.Domain.Entities;

namespace VendasAPI.Tests
{
    public class VendaServiceTests
    {
        private readonly IVendaService _vendaService;
        private readonly IVendaRepository _mockVendaRepository;
        private readonly Faker<Venda> _fakerVenda;

        public VendaServiceTests()
        {
            // Criando um mock do repositório usando NSubstitute
            _mockVendaRepository = Substitute.For<IVendaRepository>();
            _vendaService = new VendaService(_mockVendaRepository);

            // Configurando o Bogus para gerar dados fictícios de vendas
            _fakerVenda = new Faker<Venda>()
                .RuleFor(v => v.Id, f => f.IndexFaker + 1)
                .RuleFor(v => v.Cliente, f => f.Person.FullName)
                .RuleFor(v => v.ValorTotal, f => f.Finance.Amount())
                .RuleFor(v => v.Itens, f => new List<ItemVenda>());
        }

        public Faker<Venda> FakerVenda => _fakerVenda;

        [Fact]
        public void Deve_Adicionar_Uma_Nova_Venda()
        {
            var venda = FakerVenda.Generate();
            _vendaService.AddVenda(venda);

            // Verifica se o método Add foi chamado no repositório com a venda correta
            _mockVendaRepository.Received(1).Add(venda);
        }

        [Fact]
        public void Deve_Atualizar_Uma_Venda()
        {
            var venda = FakerVenda.Generate();
            _vendaService.AddVenda(venda);
            venda.Cliente = "Cliente Atualizado";
            _vendaService.UpdateVenda(venda);

            // Verifica se o método Update foi chamado no repositório com a venda atualizada
            _mockVendaRepository.Received(1).Update(venda);
        }

        [Fact]
        public void Deve_Excluir_Uma_Venda()
        {
            var venda = FakerVenda.Generate();
            _vendaService.AddVenda(venda);
            _vendaService.DeleteVenda(venda.Id);

            // Verifica se o método Delete foi chamado no repositório com o ID correto
            _mockVendaRepository.Received(1).Delete(venda.Id);
        }
    }
}
