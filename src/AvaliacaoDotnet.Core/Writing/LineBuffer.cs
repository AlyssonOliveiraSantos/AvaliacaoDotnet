using System;
using System.Collections.Generic;

namespace AvaliacaoDotnet.Core.Writing;

public class LineBuffer
{
    private readonly List<string> _linhas = new List<string>();
    private readonly SortedDictionary<string, int> _contagemPorTipo =
        new SortedDictionary<string, int>(StringComparer.Ordinal);

    public void AdicionarConteudo(string tipo, string linha)
    {
        _linhas.Add(linha);
        _contagemPorTipo[tipo] = _contagemPorTipo.TryGetValue(tipo, out var n) ? n + 1 : 1;
    }

    public void AdicionarRodape(string linha)
    {
        _linhas.Add(linha);
    }

    public IReadOnlyDictionary<string, int> ContagemPorTipo => _contagemPorTipo;

    public int TotalLinhas => _linhas.Count;

    public override string ToString() => string.Join(Environment.NewLine, _linhas);
}
