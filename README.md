# Vendinha Backend

API em C# para informatizar o controle das contas "penduradas" dos clientes de uma vendinha. Permite cadastrar clientes, registrar dívidas e marcar pagamentos.

Trabalho da disciplina C# - Módulo I (Unimar).

## Tecnologias

- C# com .NET 8 (ASP.NET Core Web API)
- Entity Framework Core 8
- SQLite
- Swagger para testar a API pelo navegador

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (confira com `dotnet --version`)

## Como executar

Pelo terminal:

```
git clone https://github.com/yoJ0gi/vendinha-backend.git
cd vendinha-backend/Vendinha.Api
dotnet run
```

Depois abra `http://localhost:5089/swagger` no navegador. Lá é possível testar todos os endpoints.

Pelo Visual Studio: abra o arquivo `Vendinha.sln` e aperte F5.

Para compilar sem executar: `dotnet build`.

## Banco de dados

O banco é um arquivo SQLite chamado `vendinha.db`, criado automaticamente na primeira execução (`EnsureCreated()` no `Program.cs`). Não é preciso instalar nada nem rodar migrations.

Para apagar os dados e começar do zero, pare a API e apague o arquivo `vendinha.db`.

O script SQL com a estrutura das tabelas está em [database/schema.sql](database/schema.sql).

## Regras de negócio

- Nome completo, CPF e data de nascimento são obrigatórios.
- O CPF precisa ser válido e não pode se repetir entre clientes. É guardado só com números.
- A data de nascimento não pode estar no futuro.
- O e-mail é opcional, mas se for informado precisa ter formato válido.
- A idade é calculada a partir da data de nascimento e não é gravada no banco.
- Um cliente só pode ter uma dívida em aberto por vez.
- O total de dívidas de um cliente soma apenas as dívidas não pagas.
- Excluir um cliente que tem dívida em aberto exige confirmação (`confirmar=true`). A exclusão remove também as dívidas dele.

## Endpoints

### Clientes

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/api/clientes?nome=&pagina=1` | Lista clientes, de 10 em 10, de quem mais deve para quem menos deve. `nome` filtra por texto contido. |
| GET | `/api/clientes/{id}` | Busca um cliente com suas dívidas, idade e total devido. |
| POST | `/api/clientes` | Cadastra um cliente. |
| PUT | `/api/clientes/{id}` | Atualiza um cliente. |
| DELETE | `/api/clientes/{id}?confirmar=false` | Exclui um cliente. |

Corpo do POST e do PUT:

```json
{
  "nomeCompleto": "Ana Souza",
  "cpf": "529.982.247-25",
  "dataNascimento": "1998-01-05",
  "email": "ana@email.com"
}
```

Resposta da listagem:

```json
{
  "pagina": 1,
  "tamanhoPagina": 10,
  "totalRegistros": 12,
  "totalPaginas": 2,
  "itens": [
    {
      "id": 5,
      "nomeCompleto": "Ana Souza",
      "cpf": "52998224725",
      "email": "ana@email.com",
      "dataNascimento": "1998-01-05T00:00:00",
      "idade": 28,
      "totalDividas": 300.0
    }
  ]
}
```

Excluir cliente com dívida em aberto, sem `confirmar=true`, não exclui e responde 409:

```json
{
  "mensagem": "Tem certeza que deseja excluir o cliente, pois ele tem dívidas em aberto?",
  "dividaEmAberto": { "valor": 300.0, "dataCriacao": "2026-11-06T09:48:13" }
}
```

### Dívidas

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/api/clientes/{clienteId}/dividas` | Lista as dívidas do cliente, das mais recentes para as mais antigas. |
| POST | `/api/clientes/{clienteId}/dividas` | Cadastra uma dívida para o cliente. |
| PATCH | `/api/clientes/{clienteId}/dividas/{dividaId}/pagar` | Marca a dívida como paga. |

Corpo do POST de dívida:

```json
{ "valor": 150.50 }
```

### Códigos de resposta

| Código | Quando acontece |
| --- | --- |
| 200 / 201 / 204 | Sucesso (consulta, criação, atualização ou exclusão). |
| 400 | Dado inválido (CPF, e-mail, data, valor, página). |
| 404 | Cliente ou dívida não encontrados. |
| 409 | CPF duplicado, segunda dívida em aberto, dívida já paga ou exclusão que pede confirmação. |

## Estrutura de pastas

```
vendinha-backend/
├── Vendinha.sln
├── README.md
├── database/
│   └── schema.sql
└── Vendinha.Api/
    ├── Controllers/    endpoints (ClientesController, DividasController)
    ├── Data/           VendinhaContext (acesso ao banco)
    ├── Models/         Cliente, Divida e as classes de entrada (Request)
    ├── Utils/          ValidadorCpf
    ├── Program.cs      configuração da API
    └── appsettings.json
```
