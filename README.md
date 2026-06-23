# AvaliacaoDotnet

App de console que lê uma base em JSON e gera um arquivo .txt no leiaute escolhido (versão 1 ou 2).

This is a challenge by [Coodesh](https://coodesh.com/).

## Stack

C#, .NET Framework 4.8, Newtonsoft.Json e NUnit nos testes.

## Como o projeto está dividido

Separei em três projetos: o `Core` com a regra de negócio, o `ConsoleApp` só com o menu, e o `Tests`.
A parte que muda entre os leiautes fica isolada em geradores (`LayoutV1Generator`, `LayoutV2Generator`)
escolhidos por uma factory pela versão, então dá pra adicionar um leiaute novo sem mexer nos que já existem.

## Rodando

```
dotnet build
dotnet run --project src/AvaliacaoDotnet.ConsoleApp
```

No menu, a opção 3 gera o arquivo e pergunta a versão do leiaute (1 ou 2). Por padrão ele usa
`data/base-dados.json`; pra gerar o leiaute 2 use a opção 1 antes e aponte pra `data/base-dados-v2.json`.
O caminho do .txt gerado aparece no final.

## Testes

```
dotnet test
```
