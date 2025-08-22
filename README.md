# Ambev.DeveloperEvolution

Este projeto é uma API .NET 8 para avaliação de desenvolvedores, seguindo padrões DDD, CQRS, MediatR e boas práticas de arquitetura.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/) (ou outro banco, conforme configuração)
- (Opcional) [Visual Studio Code](https://code.visualstudio.com/) ou outro editor de sua preferência
- (No Mac) Ferramentas de linha de comando do Xcode:  
  ```sh
  xcode-select --install
  ```

## Configuração

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/Edylso/Ambev.DeveloperEvolution.git
   cd Ambev.DeveloperEvolution
   ```

2. **Configure a connection string do banco de dados:**
   - Edite o arquivo `appsettings.Development.json` em  
     `template/backend/src/Ambev.DeveloperEvaluation.WebApi/`
   - Exemplo:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=ambev_dev;Username=seu_usuario;Password=sua_senha"
     }
     ```

3. **Restaure os pacotes:**
   ```sh
   dotnet restore
   ```

4. **(Opcional) Execute as migrations para criar o banco:**
   ```sh
   cd template/backend/src/Ambev.DeveloperEvaluation.WebApi
   dotnet ef database update
   ```

## Execução

1. **Acesse a pasta do projeto WebApi:**
   ```sh
   cd template/backend/src/Ambev.DeveloperEvaluation.WebApi
   ```

2. **Execute a aplicação:**
   ```sh
   dotnet run
   ```
   A API estará disponível em `http://localhost:5119` (ou porta definida no `launchSettings.json`).

3. **Acesse o Swagger para testar os endpoints:**
   - [http://localhost:5119/swagger](http://localhost:5119/swagger)

## Testes

1. **(Opcional) Execute os testes unitários:**
   ```sh
   dotnet test
   ```

## Estrutura do Projeto

- `Domain`: Entidades, interfaces e validações de domínio
- `Application`: Casos de uso, comandos, queries, handlers e validações
- `ORM`: Implementação dos repositórios e configurações do Entity Framework
- `WebApi`: Controllers, DTOs, Profiles e configuração da API

## Observações

- O projeto segue boas práticas de DDD, CQRS e Clean Architecture.
- Eventos de domínio como `VendaCriada`, `VendaModificada` e `VendaCancelada` são registrados no log.
- Para dúvidas ou problemas, abra uma issue no repositório.

---
