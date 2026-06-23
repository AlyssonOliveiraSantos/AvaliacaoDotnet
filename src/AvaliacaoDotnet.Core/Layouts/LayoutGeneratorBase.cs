using System.Collections.Generic;
using System.Globalization;
using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Writing;

namespace AvaliacaoDotnet.Core.Layouts;

public abstract class LayoutGeneratorBase : ILayoutGenerator
{
    public abstract int Versao { get; }

    public void Gerar(IEnumerable<Empresa> empresas, LineBuffer buffer)
    {
        foreach (var empresa in empresas)
        {
            EscreverEmpresa(buffer, empresa);
            foreach (var documento in empresa.Documentos)
            {
                EscreverDocumento(buffer, documento);
                foreach (var item in documento.Itens)
                    EscreverItem(buffer, item);
            }
        }

        EscreverResumo(buffer);
    }

    protected virtual void EscreverEmpresa(LineBuffer buffer, Empresa empresa)
    {
        buffer.AdicionarConteudo("00", $"00|{empresa.CNPJ}|{empresa.Nome}|{empresa.Telefone}");
    }

    protected virtual void EscreverDocumento(LineBuffer buffer, Documento documento)
    {
        buffer.AdicionarConteudo("01", $"01|{documento.Modelo}|{documento.Numero}|{ToMoney(documento.Valor)}");
    }

    protected abstract void EscreverItem(LineBuffer buffer, ItemDocumento item);

    protected void EscreverResumo(LineBuffer buffer)
    {
        foreach (var par in buffer.ContagemPorTipo)
            buffer.AdicionarRodape($"09|{par.Key}|{par.Value}");

        buffer.AdicionarRodape($"99|{buffer.TotalLinhas + 1}");
    }

    protected string ToMoney(decimal valor) => valor.ToString("0.00", CultureInfo.InvariantCulture);
}
