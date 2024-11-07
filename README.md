# Projeto de Avaliação - Cálcudo do CDB

## Tecnologias e frameworks utilizados

[ASP .NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet) versão 8 com C#

[Angular](https://angular.dev) com [Typescript](https://www.typescriptlang.org/), [Angular CLI](https://angular.dev/tools/cli) versão 17.3.1

[Node.js](https://nodejs.org/en) versão 20.11.1

[Coverlet](https://github.com/coverlet-coverage/coverlet) e [ReportGenerator](https://github.com/danielpalme/ReportGenerator) para relatório de cobertura

## Instalação

- Clone o repositório do projeto:

```
git clone https://github.com/andersonn-roberto/calculo-cdb-avaliacao.git
```

- Entre no diretório do projeto clonado:

```
cd calculo-cdb-avaliacao
```

- Execute o comando para restaurar as dependências e fazer build da aplicação:

```
dotnet build
```

## Executando a aplicação

- Entre no diretório da aplicação back-end:

```
cd CalculoCDB.Server
```

- Execute a aplicação:

```
dotnet run --launch-profile "https"
```

- Acesse a aplicação no endereço: [https://localhost:51218](https://localhost:51218)
  > Caso o browser reclame do certificado, continue mesmo assim.

## Executando os testes de unidade e gerando o relatório de cobertura

- Volte para o diretório do projeto clonado:

```
cd ..
```

- Instale o pacote ReportGenerator:

```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

- Execute os testes gerando o relatório de cobertura:

```
dotnet test --collect:"XPlat Code Coverage"
```

- Execute o ReportGenerator para gerar uma página HTML do relatório, por exemplo:

  > reportgenerator -reports:"C:\Projetos\TI\Estudos\CalculoCDB\CalculoCDB.Test\TestResults\a536aa1d-908a-4b0d-bfd0-3bfde5bff1ba\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

- Entre no diterório que o ReportGenerator criou:

```
cd coveragereport
```

- Abra o file explorer:

```
explorer .
```

- Dê um duplo clique no arquivo `index.html`

---

Caso tenha problemas com o relatório de cobertura, veja [esse artigo da Microsoft](https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-code-coverage?tabs=windows).
