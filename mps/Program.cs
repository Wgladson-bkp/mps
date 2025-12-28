namespace mps
{
    public class Program
    {
        static void Main(string[] args)
        { 
            if (!Configuracoes.VerificaArquivoConfig())
            {
                Configuracoes.CriaArquivoConfiguração();
            }
            string[] srg = new string[] {"-s","teste1,teste2","-p","teste3,teste4","-n","teste5,teste6" };
            var config = Configuracoes.CarregaConfiguracao();

            var argumentos = Argumentos.Filtro(srg);

            while (Validacoes.ValidaArgumentos(argumentos))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Argumentos -s, -p, -n são obrigatórios");
                Console.ForegroundColor = ConsoleColor.White;
            }

            var nomeSolution = argumentos[ARG_s].First();
            var pastaSolution = argumentos.ContainsKey(ARG_f) ? argumentos[ARG_f].First() : config.CaminhoPadrao;
            var versaoPadrao = config.VersaoPadrao;

            if (argumentos.ContainsKey(ARG_v))
            {
                if (VersoesFramework.VerificaVersao(argumentos[ARG_v].First()))
                {
                    versaoPadrao = argumentos[ARG_v].First();
                }
            }
            //var versaoPadrao = argumentos.ContainsKey(ARG_v) ? argumentos[ARG_v].First() : config.VersaoPadrao;

            Console.WriteLine("");
        }
    }
}
