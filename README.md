# Segfy HANDS-ON - Desenvolvedor Back-End Jr

Projeto para gerenciamento de apólices de seguro automóvel desenvolvido em C# utilizando ASP.NET Core Web API.

---

# Tecnologias Utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

---

# Funcionalidades

## CRUD de Apólices

- Criar Apólice
- Consultar Apólices
- Consultar Apólice por Id
- Atualizar Apólice
- Excluir Apólice

## Dados da Apólice

- Número da Apólice (gerando automaticamente)
- CPF/CNPJ do Segurado
- Placa do Veículo
- Valor do Prêmio
- Data de Início da Vigência
- Data de Fim da Vigência
- Status:
  - Ativa
  - Cancelada
  - Expirada

## Consulta Especial

Listagem das apólices que vencem nos próximos 30 dias.

---

# Arquitetura do Projeto

```
Segfy.Api
├── Controllers

Segfy.Application
├── DTOs
├── Interfaces
├── Services

Segfy.Domain
├── Entities
├── Enums

Segfy.Infrastructure
├── Data
├── Repositories

Segfy.Tests
├── Testes Unitários
```

---

# Banco de Dados

A aplicação utiliza SQLite.

Arquivo do banco:

```text
segfy.db
```
Não é necessária a instalação de SQL Server.

---

# Padrão do Número da Apólice

O número da apólice é gerado automaticamente seguindo o padrão:

```text
SEG-YYYY-XXXX
```

Exemplos:

```text
SEG-2026-0001
SEG-2026-0002
SEG-2026-0003
```

---

# Como Executar

## Pré-requisitos

- .NET SDK 10 ou superior

Verificar instalação:

```bash
dotnet --version
```

---

## Executar Automático (Recomentado)

Executar na raiz do projeto:

```text
START-HandOn.bat
```

O script irá:

- Restaurar dependências
- Compilar o projeto
- Iniciar a API automaticamente

---

## Executar (Manual)

Restaurar dependências:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Executar:

```bash
dotnet run --project Segfy.Api
```

---

# URLs

## Aplicação

```text
http://localhost:5028
```

## Swagger

```text
http://localhost:5028/swagger
```

---

# Endpoints

## Listar Apólices

```http
GET /api/apolices
```

---

## Buscar Apólice por Id

```http
GET /api/apolices/{id}
```

---

## Criar Apólice

```http
POST /api/apolices
```

Exemplo:

```json
{
  "cpfCnpj": "52998224725",
  "placa": "ABC1234",
  "valorPremio": 199.90,
  "dataInicio": "2026-07-05",
  "dataFim": "2027-07-05",
  "status": 1
}
```

---

## Atualizar Apólice

```http
PUT /api/apolices/{id}
```

---

## Excluir Apólice

```http
DELETE /api/apolices/{id}
```

---

## Consultar Apólices Vencendo nos Próximos 30 Dias

```http
GET /api/apolices/vencendo
```

---

# Front-End

Foi desenvolvida uma interface simples utilizando:

- HTML
- CSS
- JavaScript

Sem dependências externas.

Funcionalidades:

- Cadastro
- Edição
- Exclusão
- Consulta
- Consulta de vencimento em 30 dias

---

# Testes Unitários

Projeto:

```text
Segfy.Tests
```

Framework:

```text
xUnit
```

Executar:

```bash
dotnet test
```

Resultado atual:

```text
Total: 3
Passed: 3
Failed: 0
```

Testes implementados:

- Deve_Criar_Apolice_Com_Status_Ativa
- Deve_Atualizar_Status_Para_Cancelada
- Deve_Manter_Numero_Apolice

---

# Regras de Negócio Implementadas

### Número da Apólice

Gerado automaticamente:

```text
SEG-ANO-SEQUENCIAL
```

### Status

Possíveis valores:

| Valor | Status |
|---------|---------|
| 1 | Ativa |
| 2 | Cancelada |
| 3 | Expirada |

### Consulta de Vencimento

Retorna somente apólices cuja data de término esteja entre a data atual e os próximos 30 dias.

---

# Diferenciais Implementados

Além dos requisitos solicitados foram adicionados:

- Swagger/OpenAPI
- Interface Web para testes
- SQLite (sem necessidade de servidor externo)
- Testes Unitários com xUnit
- Script de inicialização (START-HandOn.bat)

---

# Autor

**Jeferson Camilo**

Desafio Técnico — Desenvolvedor(a) Back-End Jr — Segfy
