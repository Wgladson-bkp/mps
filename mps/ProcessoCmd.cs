using System.Diagnostics;
using System.Reflection;

namespace mps
{
    public static class ProcessoCmd
    {
        public static void Executa(string comando, string argumentos, string diretorio)
        {
            var processo = new Process()
            { 
               StartInfo = new ProcessStartInfo()
               {
                   FileName = comando,
                   WorkingDirectory = diretorio,
                   Arguments = argumentos,
                   RedirectStandardError = true,
                   RedirectStandardOutput = true,
                   UseShellExecute = true
               }
            
            };
            processo.Start();
            Console.WriteLine(processo.StandardOutput.ReadToEnd().ToString());
            Console.WriteLine(processo.StandardError.ReadToEnd().ToString());
            processo.
            processo.WaitForExit();
        }
    }
}
