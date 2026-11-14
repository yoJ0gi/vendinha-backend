# Vendinha

Sistema em C# para informatizar o controle das contas com dívidas em aberto dos clientes de uma vendinha. Permite cadastrar clientes, registrar dívidas e marcar pagamentos.

O repositório tem duas partes:

- **Vendinha.Api**: a API (backend), que guarda os dados e aplica as regras.
- **Vendinha.Desktop**: o aplicativo Windows Forms (frontend), que conversa com a API.

Trabalho em dupla da disciplina C# - Módulo I (Unimar).

## Tecnologias

- C# com .NET 8 (ASP.NET Core Web API)
- Entity Framework Core 8
- SQLite
- Swagger para testar a API pelo navegador
- Windows Forms (.NET 10) para o aplicativo desktop

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) para a API (confira com `dotnet --version`)
- Para o aplicativo desktop: Windows, [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) e o Visual Studio com suporte a .NET 10 (o projeto `Vendinha.Desktop` usa `net10.0-windows` e não compila em Mac ou Linux)
- No Visual Studio, o componente **.NET 8.0 Runtime** precisa estar instalado (Visual Studio Installer → Modificar → Componentes individuais). Sem ele, o Visual Studio avisa que "o projeto está direcionando uma versão do .NET que não está instalada"

## Como executar

### 1. API

Pelo terminal:

```
git clone https://github.com/yoJ0gi/vendinha-backend.git
cd vendinha-backend/Vendinha.Api
dotnet run
```

Depois abra `http://localhost:5089/swagger` no navegador. Lá é possível testar todos os endpoints.

Para compilar sem executar: `dotnet build`.

### 2. Aplicativo desktop

A API precisa estar rodando antes, na porta 5089. O aplicativo usa o endereço fixo `http://localhost:5089/`, definido em `Vendinha.Desktop/Services/ApiService.cs`.

No Visual Studio, abra o arquivo `Vendinha.sln` e inicie os dois projetos juntos: clique com o botão direito na solução, escolha "Configure Startup Projects", marque "Multiple startup projects" e coloque `Vendinha.Api` e `Vendinha.Desktop` como "Start". Depois aperte F5.

Outra opção é deixar a API rodando no terminal (passo 1) e iniciar só o `Vendinha.Desktop` pelo Visual Studio.

### Telas do aplicativo

- **Tela inicial**: abre a listagem ou o cadastro de clientes.
- **Listagem de clientes**: busca por nome (sem diferenciar maiúsculas e acentos: "álvaro" encontra "Álvaro"), paginação de 10 em 10, ordenada de quem mais deve para quem menos deve, com idade e total devido. Daqui é possível editar, excluir e abrir as dívidas do cliente. Enter no campo de busca faz a busca.
- **Cadastro e edição de cliente**: nome, CPF, data de nascimento (`dd/mm/aaaa`) e e-mail. Enter salva e Esc cancela.
- **Exclusão**: se o cliente tem dívida em aberto, o aplicativo mostra o valor e a data da dívida e pergunta "Tem certeza?" antes de excluir.
- **Dívidas do cliente**: lista as dívidas, mostra o total em aberto, lança uma nova dívida e marca como paga.

Se a API não estiver rodando, as telas avisam com a mensagem "Confira se a Vendinha.Api está rodando".

## Banco de dados

O banco é um arquivo SQLite chamado `vendinha.db`, criado automaticamente na primeira execução (`EnsureCreated()` no `Program.cs`). Não é preciso instalar nada nem rodar migrations.

Para apagar os dados e começar do zero, pare a API e apague o arquivo `vendinha.db`.

O script SQL com a estrutura das tabelas está em [database/schema.sql](database/schema.sql).

## Regras de negócio

- Nome completo, CPF e data de nascimento são obrigatórios.
- O CPF precisa ser válido e não pode se repetir entre clientes. É guardado só com números.
- A data de nascimento não pode estar no futuro nem ser de mais de 100 anos atrás.
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

Todas as respostas de erro (400, 404 e 409) vêm no mesmo formato:

```json
{ "mensagem": "CPF inválido." }
```

A exclusão que pede confirmação usa esse mesmo formato e acrescenta o campo `dividaEmAberto`.

## Estrutura de pastas

```
vendinha-backend/
├── Vendinha.sln
├── README.md
├── database/
│   └── schema.sql
├── Vendinha.Api/
│   ├── Controllers/    endpoints (BaseController, ClientesController, DividasController)
│   ├── Services/       regras de negócio (ClienteService, DividaService, Resultado)
│   ├── Data/           VendinhaContext (acesso ao banco)
│   ├── Models/         Cliente, Divida e as classes de entrada (Request)
│   ├── Utils/          ValidadorCpf
│   ├── Program.cs      configuração da API
│   └── appsettings.json
└── Vendinha.Desktop/
    ├── Models/         Cliente, Divida e as classes que recebem as respostas da API
    ├── Services/       ApiService (base), ClienteService e DividaService
    ├── Screens/        telas: ListarClientes, CadastroCliente e DividasCliente
    ├── Form1.cs        tela inicial
    └── Program.cs      ponto de entrada do aplicativo
```

### Camadas da API

A API segue a divisão em 3 camadas:

- **Apresentação** (`Controllers/`): recebe as requisições HTTP, chama o service e devolve a resposta com o código certo (200, 400, 404, 409...).
- **Negócio** (`Services/`): concentra as validações e as regras (CPF válido e único, uma dívida em aberto por cliente, confirmação na exclusão). Cada operação devolve um `Resultado`, que diz se deu certo ou qual foi o problema.
- **Dados** (`Data/` e `Models/`): o `VendinhaContext` (Entity Framework) grava e lê o banco SQLite.

## Autores

Trabalho feito em dupla:

- Lucas Jogi ([yoJ0gi](https://github.com/yoJ0gi))
- Luccas Fiorin ([luccasfiorin](https://github.com/luccasfiorin))
