
# Ambev API

## Descrição

Este projeto é uma API de vendas (VendasAPI) construída com .NET, que gerencia operações de venda, como criação, atualização e cancelamento de compras, incluindo registro de eventos como 'CompraCriada', 'CompraAlterada', 'CompraCancelada', e 'ItemCancelado'.

## Requisitos

- .NET 6.0 SDK ou superior
- Banco de dados SQL Server (ou outra solução compatível, conforme configuração)
- Ferramenta de gerenciamento de dependências (como `NuGet`)
- Docker (opcional, para uso de contêineres)
  
## Configuração

1. **Clone o repositório**:

   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd VendasAPI
   ```

2. **Instale as dependências**:

   No diretório raiz do projeto, execute o seguinte comando para restaurar as dependências:

   ```bash
   dotnet restore
   ```

3. **Configuração do banco de dados**:

   Atualize as strings de conexão do banco de dados no arquivo `appsettings.json` com suas credenciais e configurações locais.

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=VendasDB;User Id=SA;Password=<YourPassword>;"
   }
   ```

## Execução da Aplicação

1. **Compilação e execução**:

   Para compilar e executar o projeto, use o seguinte comando no diretório raiz:

   ```bash
   dotnet build
   dotnet run
   ```

   A aplicação será iniciada e estará disponível no endereço `http://localhost:5000`.

## Testes

1. **Executar testes unitários**:

   No diretório de testes, `VendasAPI.Tests`, execute os testes utilizando o comando:

   ```bash
   dotnet test
   ```

2. **Cobertura de testes**:

   Garanta que todos os testes sejam executados com sucesso e revise a cobertura dos testes.

## Documentação do Projeto

- As classes principais e eventos estão localizados na pasta `VendasAPI.Domain`.
- A API de vendas é gerenciada pelo `VendasController` que lida com operações de venda como adicionar, atualizar e deletar.
- Eventos como `CompraCriada`, `CompraAlterada` são registrados diretamente nos serviços.

## Organização do Projeto

- **VendasAPI.Data**: Contém a camada de acesso a dados.
- **VendasAPI.Domain**: Implementa as regras de negócio e eventos.
- **VendasAPI.Entities**: Define as entidades de domínio.
- **VendasAPI.Tests**: Contém os testes unitários para validação de regras de negócio.

---

Este projeto está preparado para ser executado localmente ou em um ambiente Dockerizado para maior flexibilidade de desenvolvimento e implantação.
