namespace mps
{
    public static class Argumentos
    {
        public static Dictionary<string, List<string>> Filtro(string[] args)
        {
           var lista =  new Dictionary<string, List<string>>();
            string argumento = string.Empty;
            foreach (string arg in args)
            {
                if (arg.StartsWith('-'))
                    lista[argumento = arg] = new();

                else if (arg != null)
                    lista[argumento].AddRange(arg.Split(',',StringSplitOptions.RemoveEmptyEntries));
            }
           return lista;
        }
    }
}
