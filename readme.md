# My Finance Web

## Descrição

Desenvolvido na disciplina de "Práticas de Implementação e Evolução de Software" do curso de pós graduação em Engenharia de Software da PUC Minas, **my finance** é uma aplicação para o controle de finanças pessoais.

## Requisitos

Para rodar o projeto, você precisará dos seguintes requisitos:

- [.NET Core SDK 7.0](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)

## Instalação

1. Execute o script do banco de dados `docs/myfinance.sql` no Microsoft SQL Server Management Studio para gerar o banco de dados e criar as tabelas necessárias. Esse script também populará alguma dessas bases com dados fictícios.
2. Em seu editor de código navegue até a pasta `myfinance-web-netcore`.
3. Execute o projeto:

```
dotnet run
```

4. Acesso o projeto na URL indicada no console: http://localhost:5149/

## Arquitetura
