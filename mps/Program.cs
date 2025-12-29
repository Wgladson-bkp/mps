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
            string[] srg = new string[] {"-s","Teste","-p","app,core","-n","AppRastro,Dominio" };
            var config = Configuracoes.CarregaConfiguracao();

            var argumentos = Argumentos.Filtro(srg);

            var projetos = argumentos[ARG_p];
            var nomeProjetos = argumentos[ARG_n];

            while (Validacoes.ValidaArgumentos(argumentos))
            {
                ExibeMensagemErro("ERRO: Argumentos -s, -p, -n são obrigatórios");
                argumentos = Argumentos.Filtro(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));
            }

            while (!Validacoes.ValidaQtdProjetos(projetos, nomeProjetos))
            {
                ExibeMensagemErro("Quantidade de projetos diverge do numero declarado");
                argumentos = Argumentos.Filtro(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                
                projetos = argumentos[ARG_p];
                nomeProjetos = argumentos[ARG_n];
            }

            var nomeSolution = argumentos[ARG_s].First();
            var pastaSolution = argumentos.ContainsKey(ARG_f) ? argumentos[ARG_f].First() : config.CaminhoPadrao;
            var versaoPadrao = config.VersaoPadrao;

            if (argumentos.ContainsKey(ARG_v) && VersoesFramework.VerificaVersao(argumentos[ARG_v].First()))
            {
                versaoPadrao = argumentos[ARG_v].First();
            }

           


            var caminhoPastaRaiz = Path.Combine(pastaSolution,nomeSolution);

            if (!CriaPastaSolution(caminhoPastaRaiz))
                ExibeMensagemErro("Não foi possível criar pasta da solucão");




            Console.WriteLine("fim");
            Console.ReadLine();
        }

        private static bool CriaPastaSolution(string pastaRaiz)
        {
            if (!Directory.Exists(pastaRaiz))
            {
                Directory.CreateDirectory(pastaRaiz);
                return true;
            }
            return false;
        }

        private static void ExibeMensagemErro(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
