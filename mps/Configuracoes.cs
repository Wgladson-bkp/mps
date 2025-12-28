namespace mps
{
    public static class Configuracoes
    {
        public static string? VersaoPadrao { get; set; }
        public static string? CaminhoPadrao { get; set; }
        public static Dictionary<string, ProjetoPadrao>? TipoProjetoPadrao { get; set; }
        
        public bool VerificaArquivoConfig()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                CriaArquivoConfiguração();
            }
        }

        private static void CriaArquivoConfiguração()
        {
            VersaoPadrao = VERSAO_PADRAO;
            CaminhoPadrao = CAMINHO_PADRAO;

            TipoProjetoPadrao = new Dictionary<string, ProjetoPadrao> {
                [APP] = new(CLASSLIB, APLICACAO),
                [CORE] = new(CLASSLIB, DOMINIO),
                [INFRA] = new(CLASSLIB, INFRA),
                [UIF] = new(WINFORMS, $"{APRESENTACAO}_{UIF}"),
                [UIW] = new(WPF, $"{APRESENTACAO}_{UIW}"),
                [UIB] = new(BLAZOR, $"{APRESENTACAO}_{UIB}"),
                [UIM] = new(MAUI, $"{APRESENTACAO}_{UIM}"),
                [WEBM] = new(MINIMAL_API, WEB),
                [WEBC] = new(WEB_API, WEB)
            };


            SalvaArquivoConfiguracao();
        }

        private static void SalvaArquivoConfiguracao()
        {

        }

    }
}
