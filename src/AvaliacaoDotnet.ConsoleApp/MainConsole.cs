using System;
using System.IO;
using AvaliacaoDotnet.Core.Generation;
using AvaliacaoDotnet.Core.Repositories;
using AvaliacaoDotnet.Core.Validation;

namespace AvaliacaoDotnet.ConsoleApp;

public static class MainConsole
{
    private static string _jsonPath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "base-dados.json");
    private static string _outputDir =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out");

    public static void Run()
    {
        Directory.CreateDirectory(_outputDir);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Configurar arquivo .json (base de dados)");
            Console.WriteLine("2. Configurar diretorio de output");
            Console.WriteLine("3. Gerar arquivo");
            Console.WriteLine("0. Sair");
            Console.Write("Opcao: ");

            var opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    ConfigurarJson();
                    break;
                case "2":
                    ConfigurarOutput();
                    break;
                case "3":
                    GerarArquivo();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcao invalida.");
                    break;
            }
        }
    }

    private static void ConfigurarJson()
    {
        Console.Write("Informe o caminho completo do arquivo .json: ");
        var caminho = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(caminho) && File.Exists(caminho))
        {
            _jsonPath = caminho;
            Console.WriteLine("JSON configurado: " + _jsonPath);
        }
        else
        {
            Console.WriteLine("Caminho invalido ou arquivo nao encontrado.");
        }
    }

    private static void ConfigurarOutput()
    {
        Console.Write("Informe o diretorio de saida para o .txt: ");
        var diretorio = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(diretorio))
        {
            _outputDir = diretorio;
            Directory.CreateDirectory(_outputDir);
            Console.WriteLine("Diretorio de saida configurado: " + _outputDir);
        }
        else
        {
            Console.WriteLine("Diretorio invalido.");
        }
    }

    private static void GerarArquivo()
    {
        Console.Write("Informe o numero da versao do leiaute: ");
        if (!int.TryParse(Console.ReadLine(), out var versao))
        {
            Console.WriteLine("Versao invalida. Informe um numero inteiro.");
            return;
        }

        try
        {
            var repositorio = new JsonEmpresaRepository(_jsonPath);
            var empresas = repositorio.Carregar();

            var gerador = new GeradorDeArquivo();
            var caminho = gerador.Gerar(empresas, versao, _outputDir);

            Console.WriteLine("Arquivo gerado em: " + caminho);
        }
        catch (ValidacaoException ex)
        {
            Console.WriteLine("Falha na validacao:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao gerar arquivo: " + ex.Message);
        }
    }
}
