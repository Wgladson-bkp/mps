using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mps
{
    public static class VersoesFramework
    {
        public static bool VerificaVersao(string version)
        {
            return Version.Contains(version);
        }
        private static List<string> Version { get; set; } = new()
        {
            // =========================
            // .NET Framework (clássico)
            // =========================
            "net461",
            "net462",
            "net47",
            "net471",
            "net472",
            "net48",

            // =========================
            // .NET Core
            // =========================
            "netcoreapp1.0",
            "netcoreapp1.1",
            "netcoreapp2.0",
            "netcoreapp2.1",
            "netcoreapp2.2",
            "netcoreapp3.0",
            "netcoreapp3.1",

            // =========================
            // .NET (unificado)
            // =========================
            "net5.0",
            "net6.0",
            "net7.0",
            "net8.0",
            "net9.0",

            // =========================
            // .NET Standard
            // =========================
            "netstandard1.0",
            "netstandard1.1",
            "netstandard1.2",
            "netstandard1.3",
            "netstandard1.4",
            "netstandard1.5",
            "netstandard1.6",
            "netstandard2.0",
            "netstandard2.1",

            // =========================
            // Plataformas específicas
            // =========================
            "net8.0-windows",
            "net8.0-windows10.0.19041.0",
            "net8.0-android",
            "net8.0-ios",
            "net8.0-macos"
        };
    }
}
