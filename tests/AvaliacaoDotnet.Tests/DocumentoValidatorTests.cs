using System.Collections.Generic;
using AvaliacaoDotnet.Core.Domain;
using AvaliacaoDotnet.Core.Validation;
using NUnit.Framework;

namespace AvaliacaoDotnet.Tests;

public class DocumentoValidatorTests
{
    [Test]
    public void Validar_QuandoSomaConfere_NaoLancaExcecao()
    {
        var empresas = TestData.UmaEmpresaUmDocumento();

        Assert.DoesNotThrow(() => DocumentoValidator.Validar(empresas));
    }

    [Test]
    public void Validar_QuandoSomaDivergente_LancaValidacaoException()
    {
        var empresas = new List<Empresa>
        {
            new Empresa
            {
                CNPJ = "1",
                Documentos = new List<Documento>
                {
                    new Documento
                    {
                        Numero = "001",
                        Valor = 100m,
                        Itens = new List<ItemDocumento>
                        {
                            new ItemDocumento { Valor = 60m },
                            new ItemDocumento { Valor = 30m }
                        }
                    }
                }
            }
        };

        Assert.Throws<ValidacaoException>(() => DocumentoValidator.Validar(empresas));
    }
}
