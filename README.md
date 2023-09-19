# Projeto FGV.ServicoOrdenacaoDeLivros

Este projeto é uma aplicação .NET que fornece funcionalidades para ordenar livros.

## Pré-requisitos

- .NET 7.0 ou superior
- SQL Server

## Como configurar

1. Clone o repositório para a sua máquina local.
2. Abra o projeto no Visual Studio ou em seu IDE preferido.
3. Atualize a string de conexão no arquivo `appsettings.json` para apontar para o seu servidor SQL Server.

## Como executar

1. No Visual Studio, defina o projeto `FGV.ServicoOrneacaoDeLivros.WebAPI` como o projeto de inicialização.
2. Pressione `F5` para iniciar a aplicação.

## Como atualizar o banco de dados

1. Abra o Console do Gerenciador de Pacotes (Package Manager Console).
2. Selecione `FGV.ServicoOrneacaoDeLivros.InfraStructure` como o projeto padrão.
3. Execute o comando `Update-Database`.

Isso irá aplicar todas as migrações pendentes ao banco de dados.

## Testes unitários

Os testes unitários estão localizados no projeto `FGV.ServicoOrdenacaoDeLivros.Tests`. Você pode executá-los usando o Test Explorer no Visual Studio.

## Uso da API

A API fornece um endpoint para ordenar livros. O endpoint aceita um objeto JSON com a seguinte estrutura:

```json
{
  "orderTypeEnum": 0,
  "books": [
    {
      "id": 0,
      "title": "string",
      "author": "string",
      "edition": 0
    }
  ]
}
```
O campo `orderTypeEnum` determina a ordem em que os livros serão retornados. Os valores possíveis são:

- `1`: Título ascendente
- `2`: Autor ascendente, Título descendente
- `3`: Edição descendente, Autor descendente, Título ascendente

