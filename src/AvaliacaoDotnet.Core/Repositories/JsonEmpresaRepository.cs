using System;
using System.Collections.Generic;
using System.IO;
using AvaliacaoDotnet.Core.Domain;
using Newtonsoft.Json;
namespace AvaliacaoDotnet.Core.Repositories
{

    public class JsonEmpresaRepository : IEmpresaRepository
    {
        private readonly string _caminhoJson;
        public JsonEmpresaRepository(string caminhoJson)
        {
            _caminhoJson = caminhoJson;
        }

        public IReadOnlyList<Empresa> Carregar()
        {
            if (!File.Exists(_caminhoJson))
            {
                throw new FileNotFoundException($"Arquivo JSON não encontrado: {_caminhoJson}");
            }
            try
            {
                var json = File.ReadAllText(_caminhoJson);
                var empresas = JsonConvert.DeserializeObject<List<Empresa>>(json);
                if (empresas == null)
                {
                    throw new Exception("Falha ao desserializar o JSON. O conteúdo não corresponde ao tipo Empresa.");
                }

                return empresas;
            } catch (Exception ex)
            {
                throw new Exception("Falha ao desserializar o JSON. Verifique se o arquivo esta no formato esperado. Detalhes:" + ex.Message , ex);


            }
        }
    }
}