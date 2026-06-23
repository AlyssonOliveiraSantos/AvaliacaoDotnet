using System;
using AvaliacaoDotnet.Core.Layouts;
using NUnit.Framework;

namespace AvaliacaoDotnet.Tests;

public class LayoutGeneratorFactoryTests
{
    [Test]
    public void Criar_Versao1_RetornaLayoutV1()
    {
        var layout = LayoutGeneratorFactory.Criar(1);

        Assert.That(layout, Is.TypeOf<LayoutV1Generator>());
        Assert.That(layout.Versao, Is.EqualTo(1));
    }

    [Test]
    public void Criar_Versao2_RetornaLayoutV2()
    {
        var layout = LayoutGeneratorFactory.Criar(2);

        Assert.That(layout, Is.TypeOf<LayoutV2Generator>());
        Assert.That(layout.Versao, Is.EqualTo(2));
    }

    [Test]
    public void Criar_VersaoInexistente_LancaNotSupportedException()
    {
        Assert.Throws<NotSupportedException>(() => LayoutGeneratorFactory.Criar(99));
    }
}
