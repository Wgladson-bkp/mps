namespace mps
{
    public class Validacoes
    {
        public static bool ValidaArgumentos(Dictionary<string,List<string>> argumentos)
        {
            return 
                !argumentos.ContainsKey(ARG_s) || 
                !argumentos.ContainsKey(ARG_p) || 
                !argumentos.ContainsKey(ARG_n);
        }

        public static bool ValidaQtdProjetos(List<string> projetos, List<string> nomes)
        {
            return projetos.Count == nomes.Count;
        }

    }
}
