using System;
using AvaliacaoDotnet.Core.Layouts;
using AvaliacaoDotnet.Core.Writing;
using NUnit.Framework;

namespace AvaliacaoDotnet.Tests;

public class LayoutV1GeneratorTests
{
    private static string[] Gerar()
    {
        var buffer = new LineBuffer();
        new LayoutV1Generator().Gerar(TestData.UmaEmpresaUmDocumento(), buffer);
        return buffer.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    }

    [Test]
    public void Gerar_ProduzLinhasNoFormatoDaVersao1()
    {
        var linhas = Gerar();

        Assert.That(linhas[0], Is.EqualTo("00|123|Empresa|999"));
        Assert.That(linhas[1], Is.EqualTo("01|NF|001|100.00"));
        Assert.That(linhas[2], Is.EqualTo("02|Item A|60.00"));
        Assert.That(linhas[3], Is.EqualTo("02|Item B|40.00"));
    }

    [Test]
    public void Gerar_NaoProduzLinha03_NaVersao1()
    {
        var texto = string.Join(Environment.NewLine, Gerar());
        Assert.That(texto, Does.Not.Contain("03|"));
    }

    [Test]
    public void Gerar_EmiteRodape09E99()
    {
        var linhas = Gerar();

        Assert.That(linhas[4], Is.EqualTo("09|00|1"));
        Assert.That(linhas[5], Is.EqualTo("09|01|1"));
        Assert.That(linhas[6], Is.EqualTo("09|02|2"));
        Assert.That(linhas[7], Is.EqualTo("99|8"));
    }
}
