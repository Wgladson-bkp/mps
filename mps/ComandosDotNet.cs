using System;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace mps
{
    public class ComandosDotNet
    {
        public static void CriaSolution(string nomeSolution, string pastaSaida)
        {
            ProcessoCmd.Executa("dotnet", $"new sln -n {nomeSolution}", pastaSaida);
        }

        public static void CriaProjeto(string tipoProjeto, string nome, string versao, string pastaSaida)
        {

            ProcessoCmd.Executa("dotnet", $"new {tipoProjeto} -n {nome} -f {versao}", pastaSaida);
        }

        public static void AdicionaProjASolution(string caminho, string projeto, string pastaRaiz)
        {
            var cmd = $"sln add {caminho}\\{projeto}.csproj";
            ProcessoCmd.Executa("dotnet", $"{cmd}", pastaRaiz);
        }

    }
}
