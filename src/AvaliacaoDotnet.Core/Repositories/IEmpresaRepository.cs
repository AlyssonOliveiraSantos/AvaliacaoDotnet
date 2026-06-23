using System.Collections.Generic;
using AvaliacaoDotnet.Core.Domain;

namespace AvaliacaoDotnet.Core.Repositories
{

    public interface IEmpresaRepository
    {
        IReadOnlyList<Empresa> Carregar();
    }
}