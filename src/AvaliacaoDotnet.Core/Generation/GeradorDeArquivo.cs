using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Layouts;
using AvaliacaoDotnet.Core.Validation;
using AvaliacaoDotnet.Core.Writing;

namespace AvaliacaoDotnet.Core.Generation;

public class GeradorDeArquivo
{
    public string Gerar(IReadOnlyList<Empresa> empresas, int versao, string diretorioSaida)
    {
        DocumentoValidator.Validar(empresas);

        var layout = LayoutGeneratorFactory.Criar(versao);

        var buffer = new LineBuffer();
        layout.Gerar(empresas, buffer);

        Directory.CreateDirectory(diretorioSaida);
        var nomeArquivo = $"saida_leiaute_v{versao:00}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var caminhoFinal = Path.Combine(diretorioSaida, nomeArquivo);
        File.WriteAllText(caminhoFinal, buffer.ToString(), new UTF8Encoding(false));

        return caminhoFinal;
    }
}
