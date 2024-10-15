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
            // Criando um mock do reposit�rio usando NSubstitute
            _mockVendaRepository = Substitute.For<IVendaRepository>();
            _vendaService = new VendaService(_mockVendaRepository);

            // Configurando o Bogus para gerar dados fict�cios de vendas
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

            // Verifica se o m�todo Add foi chamado no reposit�rio com a venda correta
            _mockVendaRepository.Received(1).Add(venda);
        }

        [Fact]
        public void Deve_Atualizar_Uma_Venda()
        {
            var venda = FakerVenda.Generate();
            _vendaService.AddVenda(venda);
            venda.Cliente = "Cliente Atualizado";
            _vendaService.UpdateVenda(venda);

            // Verifica se o m�todo Update foi chamado no reposit�rio com a venda atualizada
            _mockVendaRepository.Received(1).Update(venda);
        }

        [Fact]
        public void Deve_Excluir_Uma_Venda()
        {
            var venda = FakerVenda.Generate();
            _vendaService.AddVenda(venda);
            _vendaService.DeleteVenda(venda.Id);

            // Verifica se o m�todo Delete foi chamado no reposit�rio com o ID correto
            _mockVendaRepository.Received(1).Delete(venda.Id);
        }
    }
}
