using AvaliacaoDotnet.Core.Writing;
using NUnit.Framework;

namespace AvaliacaoDotnet.Tests;

public class LineBufferTests
{
    [Test]
    public void AdicionarConteudo_IncrementaContagemPorTipo()
    {
        var buffer = new LineBuffer();
        buffer.AdicionarConteudo("00", "00|a");
        buffer.AdicionarConteudo("02", "02|x");
        buffer.AdicionarConteudo("02", "02|y");

        Assert.That(buffer.ContagemPorTipo["00"], Is.EqualTo(1));
        Assert.That(buffer.ContagemPorTipo["02"], Is.EqualTo(2));
        Assert.That(buffer.TotalLinhas, Is.EqualTo(3));
    }

    [Test]
    public void AdicionarRodape_NaoEntraNaContagemPorTipo()
    {
        var buffer = new LineBuffer();
        buffer.AdicionarConteudo("00", "00|a");
        buffer.AdicionarRodape("99|2");

        Assert.That(buffer.TotalLinhas, Is.EqualTo(2));
        Assert.That(buffer.ContagemPorTipo.ContainsKey("99"), Is.False);
    }
}
