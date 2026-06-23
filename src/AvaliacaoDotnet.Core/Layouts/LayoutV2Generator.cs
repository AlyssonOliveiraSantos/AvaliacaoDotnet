using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Writing;

namespace AvaliacaoDotnet.Core.Layouts;

public class LayoutV2Generator : LayoutGeneratorBase
{
    public override int Versao => 2;

    protected override void EscreverItem(LineBuffer buffer, ItemDocumento item)
    {
        buffer.AdicionarConteudo("02", $"02|{item.NumeroItem}|{item.Descricao}|{ToMoney(item.Valor)}");

        foreach (var categoria in item.Categorias)
            buffer.AdicionarConteudo("03", $"03|{categoria.NumeroCategoria}|{categoria.DescricaoCategoria}");
    }
}
