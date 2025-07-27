# SuperHeroes API 🦸‍♂️

Uma API REST completa para gerenciamento de super-heróis e seus superpoderes, desenvolvida em .NET 8 seguindo os princípios da Clean Architecture.

## 📋 Sobre o Projeto

Esta aplicação permite o cadastro, consulta, atualização e exclusão de super-heróis, além do gerenciamento de superpoderes. Cada super-herói pode possuir múltiplos superpoderes, criando um sistema flexível e escalável.

### ✨ Funcionalidades

- ✅ **CRUD completo de Super-heróis**
  - Criar novo super-herói
  - Listar todos os super-heróis
  - Buscar super-herói por ID
  - Atualizar dados do super-herói
  - Remover super-herói

- ✅ **Gerenciamento de Superpoderes**
  - Cadastrar novos superpoderes
  - Listar todos os superpoderes disponíveis
  - Associar múltiplos poderes aos heróis

- ✅ **Métricas da aplicação**
  - Endpoint para monitoramento

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** com a seguinte estrutura:

```
SuperHeroes/
├── src/
│   ├── SuperHeroes.Api/              # Camada de apresentação (Controllers, Middlewares)
│   ├── SuperHeroes.Application/      # Casos de uso e regras de negócio
│   ├── SuperHeroes.Communication/    # DTOs de requisição e resposta
│   ├── SuperHeroes.Domain/          # Entidades e DTOs do domínio
│   ├── SuperHeroes.Exception/       # Tratamento de exceções
│   └── SuperHeroes.Infrastructure/  # Acesso a dados e serviços externos
├── docker-compose.yml              # Configuração do banco PostgreSQL
└── SuperHeroes.sln                # Arquivo da solução
```

## 🛠️ Tecnologias Utilizadas

- **Framework**: .NET 8
- **ORM**: Entity Framework Core 8.0.18
- **Banco de Dados**: PostgreSQL 13.21
- **Documentação**: Swagger/OpenAPI
- **Containerização**: Docker & Docker Compose
- **Arquitetura**: Clean Architecture
- **Patterns**: Repository, Dependency Injection

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Passo a passo

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/desafio-superherois.git
   cd desafio-superherois/SuperHeroes
   ```

2. **Subir o banco de dados PostgreSQL**
   ```bash
   docker-compose up -d
   ```

3. **Restaurar dependências**
   ```bash
   dotnet restore
   ```

4. **Executar as migrações do banco**
   ```bash
   dotnet ef database update --project ./src/SuperHeroes.Infrastructure/ --startup-project ./src/SuperHeroes.Api/
   ```

5. **Executar a aplicação**
   ```bash
   dotnet run --project ./src/SuperHeroes.Api/
   ```

6. **Acessar a documentação da API**
   - Swagger UI: `https://localhost:7000/swagger` (HTTPS)
   - Swagger UI: `http://localhost:5000/swagger` (HTTP)

## 📡 Endpoints da API

### Super-heróis

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `POST` | `/api/superheroes` | Cadastrar novo super-herói |
| `GET` | `/api/superheroes` | Listar todos os super-heróis |
| `GET` | `/api/superheroes/{id}` | Buscar super-herói por ID |
| `PUT` | `/api/superheroes/{id}` | Atualizar super-herói |
| `DELETE` | `/api/superheroes/{id}` | Remover super-herói |

### Superpoderes

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `POST` | `/api/superpowers` | Cadastrar novo superpoder |
| `GET` | `/api/superpowers` | Listar todos os superpoderes |

### Métricas

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/metrics` | Obter métricas da aplicação |

## 📊 Modelo de Dados

### SuperHero
```json
{
  "id": 1,
  "name": "Peter Parker",
  "heroName": "Spider-Man",
  "birthDate": "1995-08-10T00:00:00",
  "height": 1.78,
  "weight": 76.0,
  "superPowers": [
    {
      "id": 1,
      "name": "Super Força",
      "description": "Força sobre-humana"
    }
  ]
}
```

### SuperPower
```json
{
  "id": 1,
  "name": "Voo",
  "description": "Capacidade de voar"
}
```

## 🐳 Docker

### Banco de Dados

O projeto inclui um `docker-compose.yml` para subir uma instância do PostgreSQL:

```yaml
services:
  postgres:
    image: postgres:13.21-alpine3.21
    ports:
      - 5432:5432
    environment:
      - POSTGRES_USER=postgres
      - POSTGRES_PASSWORD=docker
      - POSTGRES_DB=superheroes_db
```

### Comandos Docker úteis

```bash
# Subir apenas o banco
docker-compose up -d postgres

# Parar os serviços
docker-compose down

# Ver logs do banco
docker-compose logs postgres
```

## 🔧 Configuração

### String de Conexão

A string de conexão padrão está configurada em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Port=5432;Database=superheroes_db;User Id=postgres;Password=docker;"
  }
}
```

## 📝 Padrões de Resposta

### Sucesso
- `200 OK` - Consulta realizada com sucesso
- `201 Created` - Recurso criado com sucesso
- `204 No Content` - Operação realizada sem conteúdo de retorno

### Erro
- `400 Bad Request` - Dados inválidos na requisição
- `404 Not Found` - Recurso não encontrado
- `409 Conflict` - Conflito (ex: nome duplicado)

### Exemplo de resposta de erro
```json
{
  "errors": [
    "Nome do herói é obrigatório",
    "Data de nascimento deve ser informada"
  ]
}
```

---

## Decisões de Projeto

A aplicação foi estruturada com Clean Architecture para garantir separação de responsabilidades, facilitando manutenção e testes. Usei .NET 8 e Entity Framework Core pela performance e integração com o ecossistema. PostgreSQL foi escolhido pela confiabilidade e o uso de Docker simplifica o ambiente de desenvolvimento. A divisão em módulos e o uso de padrões como Repository e Injeção de Dependência garantem um código limpo, escalável e preparado para evoluções futuras.
