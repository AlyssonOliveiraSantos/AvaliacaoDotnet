using System.Collections.Generic;
using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Writing;

namespace AvaliacaoDotnet.Core.Layouts;

public interface ILayoutGenerator
{
    int Versao { get; }
    void Gerar(IEnumerable<Empresa> empresas, LineBuffer buffer);
}
