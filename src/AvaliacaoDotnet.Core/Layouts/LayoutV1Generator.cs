using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Writing;

namespace AvaliacaoDotnet.Core.Layouts;

public class LayoutV1Generator : LayoutGeneratorBase
{
    public override int Versao => 1;

    protected override void EscreverItem(LineBuffer buffer, ItemDocumento item)
    {
        buffer.AdicionarConteudo("02", $"02|{item.Descricao}|{ToMoney(item.Valor)}");
    }
}
