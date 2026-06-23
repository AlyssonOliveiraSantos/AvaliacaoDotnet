using System;

namespace AvaliacaoDotnet.Core.Layouts;

public static class LayoutGeneratorFactory
{
    public static ILayoutGenerator Criar(int versao)
    {
        switch (versao)
        {
            case 1:
                return new LayoutV1Generator();
            case 2:
                return new LayoutV2Generator();
            default:
                throw new NotSupportedException($"Leiaute versão {versao} não é suportado.");
        }
    }
}
