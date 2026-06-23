namespace AvaliacaoDotnet.Core.Domain;
using System.Collections.Generic;
public class Documento
    {
        public string Modelo { get; set; }
        public string Numero { get; set; }
        public decimal Valor { get; set; }
        public List<ItemDocumento> Itens { get; set; } = new List<ItemDocumento>();
    }