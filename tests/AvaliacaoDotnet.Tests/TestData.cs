using System.Collections.Generic;
using AvaliacaoDotnet.Core.Domain;

namespace AvaliacaoDotnet.Tests;

public static class TestData
{
    public static List<Empresa> UmaEmpresaUmDocumento()
    {
        return new List<Empresa>
        {
            new Empresa
            {
                CNPJ = "123",
                Nome = "Empresa",
                Telefone = "999",
                Documentos = new List<Documento>
                {
                    new Documento
                    {
                        Modelo = "NF",
                        Numero = "001",
                        Valor = 100m,
                        Itens = new List<ItemDocumento>
                        {
                            new ItemDocumento
                            {
                                NumeroItem = 1,
                                Descricao = "Item A",
                                Valor = 60m,
                                Categorias = new List<Categoria>
                                {
                                    new Categoria { NumeroCategoria = 1, DescricaoCategoria = "Grupo 1" },
                                    new Categoria { NumeroCategoria = 2, DescricaoCategoria = "Classe 2" }
                                }
                            },
                            new ItemDocumento
                            {
                                NumeroItem = 2,
                                Descricao = "Item B",
                                Valor = 40m
                            }
                        }
                    }
                }
            }
        };
    }
}
