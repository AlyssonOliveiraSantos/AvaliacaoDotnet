namespace AvaliacaoDotnet.Core.Domain;
using System.Collections.Generic;
public class ItemDocumento
{
    public int NumeroItem {get; set;}
    public string Descricao {get; set;}
    public decimal Valor {get; set;}
    public List<Categoria> Categorias {get; set;} = new List<Categoria>();

}