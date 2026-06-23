using System;
using System.Collections.Generic;
using System.Linq;
using AvaliacaoDotnet.Core.Domain;

namespace AvaliacaoDotnet.Core.Validation;

public static class DocumentoValidator
{
    private const decimal Tolerancia = 0.01m;

    public static void Validar(IEnumerable<Empresa> empresas)
    {
        var erros = new List<string>();

        foreach (var empresa in empresas)
        {
            foreach (var documento in empresa.Documentos)
            {
                var somaItens = documento.Itens.Sum(i => i.Valor);
                if (Math.Abs(somaItens - documento.Valor) > Tolerancia)
                {
                    erros.Add(
                        $"Empresa '{empresa.CNPJ}', documento '{documento.Numero}': " +
                        $"soma dos itens ({somaItens:0.00}) difere do valor do documento ({documento.Valor:0.00}).");
                }
            }
        }

        if (erros.Count > 0)
        {
            throw new ValidacaoException(
                $"Validação falhou: {erros.Count} documento(s) com soma divergente." +
                Environment.NewLine + string.Join(Environment.NewLine, erros));
        }
    }
}
