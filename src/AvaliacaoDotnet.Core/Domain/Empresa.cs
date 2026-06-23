namespace AvaliacaoDotnet.Core.Domain;
using System.Collections.Generic;

    public class Empresa
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<Documento> Documentos { get; set; } = new List<Documento>();
    }