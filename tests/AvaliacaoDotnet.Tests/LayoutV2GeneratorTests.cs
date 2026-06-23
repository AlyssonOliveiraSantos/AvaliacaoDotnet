using System;
using AvaliacaoDotnet.Core.Layouts;
using AvaliacaoDotnet.Core.Writing;
using NUnit.Framework;

namespace AvaliacaoDotnet.Tests;

public class LayoutV2GeneratorTests
{
    private static string Gerar()
    {
        var buffer = new LineBuffer();
        new LayoutV2Generator().Gerar(TestData.UmaEmpresaUmDocumento(), buffer);
        return buffer.ToString();
    }

    [Test]
    public void Gerar_Item02_IncluiNumeroItem()
    {
        var texto = Gerar();

        Assert.That(texto, Does.Contain("02|1|Item A|60.00"));
        Assert.That(texto, Does.Contain("02|2|Item B|40.00"));
    }

    [Test]
    public void Gerar_ProduzLinhas03PorCategoria()
    {
        var texto = Gerar();

        Assert.That(texto, Does.Contain("03|1|Grupo 1"));
        Assert.That(texto, Does.Contain("03|2|Classe 2"));
    }

    [Test]
    public void Gerar_Contagem09_IncluiTipo03()
    {
        var texto = Gerar();

        Assert.That(texto, Does.Contain("09|03|2"));
    }
}
