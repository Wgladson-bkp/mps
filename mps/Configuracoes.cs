using System.Text.Json;

namespace mps
{
    public class Configuracoes
    {
        public Configuracoes()
        {

        }
        public string? VersaoPadrao { get; set; }
        public string? CaminhoPadrao { get; set; }
        public Dictionary<string, ProjetoPadrao>? TipoProjetoPadrao { get; set; }

        public static bool VerificaArquivoConfig()
        {
            return File.Exists(CONFIG_PATH);
        }

      

        public static void CriaArquivoConfiguração()
        {
            var config = new Configuracoes()
            {
                VersaoPadrao = VERSAO_PADRAO,
                CaminhoPadrao = CAMINHO_PADRAO,
                TipoProjetoPadrao = Templates.MpsTemplates
              
            };


            SalvaArquivoConfiguracao(config);
        }

        private static void SalvaArquivoConfiguracao(Configuracoes configuracoes)
        {
            File.WriteAllText(CONFIG_PATH, JsonSerializer.Serialize(configuracoes, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static Configuracoes CarregaConfiguracao()
        {
            var config = JsonDocument.Parse(File.ReadAllText(CONFIG_PATH));
            var root = config.RootElement;

            var configuracoes = new Configuracoes()
            {
                VersaoPadrao = root.GetProperty(nameof(VersaoPadrao)).ToString(),
                CaminhoPadrao = root.GetProperty(nameof(CaminhoPadrao)).ToString(),
                TipoProjetoPadrao = root.GetProperty(nameof(TipoProjetoPadrao)).Deserialize<Dictionary<string,ProjetoPadrao>>()
            };

            return configuracoes;
        }

    }
}
