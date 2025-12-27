namespace mps
{
    public static class Configuracoes
    {
        public static string? VersaoPadrao { get; set; }
        public static string? CaminhoPadrao { get; set; }
        public static Dictionary<string, string>? TipoProjetoPadrao { get; set; }
        public bool VerificaArquivoConfig()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                CriaArquivoConfiguração();
            }
        }

        private static void CriaArquivoConfiguração()
        {
            TipoProjetoPadrao = new Dictionary<string, string> {
                ["app"] = new("classlib", "Application"),
                ["core"] = new("classlib", "Domain"),
                ["infra"] = new("classlib", "Infrastructure"),
                ["uif"] = new("winforms", "Presentation_uif"),
                ["uiw"] = new("wpf", "Presentation_uiw"),
                ["uib"] = new("blazor", "Presentation_uib"),
                ["uim"] = new("maui", "Presentation_uim"),
                ["webm"] = new("minimalapi", "Web"),
                ["webc"] = new("webapi", "Web")

            };


            SalvaArquivoConfiguracao();
        }

        private static void SalvaArquivoConfiguracao()
        {

        }

    }
}
