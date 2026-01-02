using System;
using System.Text;
using System.Text.RegularExpressions;

namespace mps
{
    public class Program
    {

        private static string VersaoPadrao = string.Empty;
        private static string PastaSolution = string.Empty;
        private static string CaminhoPastaRaiz = string.Empty;
        private static string PastaSRC = string.Empty;

        static void Main(string[] args)
        {
            if (!Configuracoes.VerificaArquivoConfig())
            {
                Configuracoes.CriaArquivoConfiguração();
            }
            string[] srg = new string[] { "-s", "Teste", "-p", "app,core", "-n", "AppRastro,Dominio" };
            var config = Configuracoes.CarregaConfiguracao();

            var argumentos = Argumentos.Filtro(srg);

            var projetos = argumentos[ARG_p];
            var nomeProjetos = argumentos[ARG_n];

            while (Validacoes.ValidaArgumentos(argumentos))
            {
                ExibeMensagemErro("ERRO: Argumentos -s, -p, -n são obrigatórios");
                argumentos = Argumentos.Filtro(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }

            while (!Validacoes.ValidaQtdProjetos(projetos, nomeProjetos))
            {
                ExibeMensagemErro("Quantidade de projetos diverge do numero declarado");
                argumentos = Argumentos.Filtro(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

                projetos = argumentos[ARG_p];
                nomeProjetos = argumentos[ARG_n];
            }

            var nomeSolution = argumentos[ARG_s].First();
            PastaSolution = argumentos.ContainsKey(ARG_f) ? argumentos[ARG_f].First() : config.CaminhoPadrao;
            VersaoPadrao = config.VersaoPadrao;

            if (argumentos.ContainsKey(ARG_v) && VersoesFramework.VerificaVersao(argumentos[ARG_v].First()))
            {
                VersaoPadrao = argumentos[ARG_v].First();
            }




            CaminhoPastaRaiz = Path.Combine(PastaSolution, nomeSolution);

            if (!CriaPastaSolution(CaminhoPastaRaiz))
                ExibeMensagemErro("Não foi possível criar pasta da solucão");

            ComandosDotNet.CriaSolution(nomeSolution, CaminhoPastaRaiz);

            CriaPastaSRC(CaminhoPastaRaiz);

            CriaPastasProjetos(projetos, nomeProjetos, config);


        }



        private static void CriaPastasProjetos(List<string> listaProjetos, List<string> listaNomes, Configuracoes config)
        {
            for (int i = 0; i < listaProjetos.Count; i++)
            {
                var nome = listaNomes[i];

                var projeto = listaProjetos[i];

                var configProj = config?.TipoProjetoPadrao[projeto];

                var camada = configProj.Modelo.Split('_')[0];

                var pastaCamda = Path.Combine(PastaSRC, camada);

                Directory.CreateDirectory(pastaCamda);

                CriaProjeto(nome, pastaCamda, camada);

                AdicionaProjetoSolution($"{pastaCamda}\\{nome}", nome);
            }
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

        private static void CriaPastaSRC(string pastaRaiz)
        {
            PastaSRC = Path.Combine(pastaRaiz, "src");
            Directory.CreateDirectory(PastaSRC);
        }

        private static void CriaProjeto(string nome, string caminho, string camada)
        {
            var tipoProjeto = Templates.MpsTemplates.Values.FirstOrDefault(x => x.Modelo == camada);
            ComandosDotNet.CriaProjeto(tipoProjeto.Tipo, nome, VersaoPadrao, caminho);

            var template = caminho.Split("\\src\\")[1];

            CriaEstruturaProjeto($"{caminho}\\{nome}", nome, template);
        }

        private static void CriaEstruturaProjeto(string caminho, string projeto ,string template)
        {
            var estrtura = Templates.Estrutura(template);
            var matches = Regex.Matches(estrtura, "<Folder Include=\"([^\"]+)\"");

            foreach (Match m in matches)
            {
                string folder = m.Groups[1].Value;
                Directory.CreateDirectory(Path.Combine(caminho, folder));
            }

           
            string csproj = estrtura
                    .Replace("MpsDefaultFramework", VersaoPadrao);

            File.WriteAllText($"{caminho}\\{projeto}.csproj", csproj, Encoding.UTF8);
        }

        private static void AdicionaProjetoSolution(string caminho, string projeto)
        {
            ComandosDotNet.AdicionaProjASolution(caminho, projeto, CaminhoPastaRaiz);
        }


        private static void ExibeMensagemErro(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}