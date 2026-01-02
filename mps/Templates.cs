namespace mps
{
    public class Templates
    {
        public Templates()
        {
            CreateTemplates();
        }

        private Dictionary<string, string>? TemplatesPadrao {  get; set; }

        private void CreateTemplates()
        {
            TemplatesPadrao = new()
            {
                {APLICACAO,Aplicacao()},
                {DOMINIO,Dominio()},
                {INFRAESTRUTURA,Infraestrutura()},
                {APRESENTACAO,ApresentacaoUif()}

            };
        }

        public void SalvaTemplates()
        {

        }

        public static Dictionary<string, ProjetoPadrao> MpsTemplates { get; set; } = new Dictionary<string, ProjetoPadrao>
            {
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

        public static string Estrutura(string tipo)
        {
            switch (tipo)
            {
                case APLICACAO:
                    return Aplicacao();
                case DOMINIO:
                    return Dominio();
                case INFRAESTRUTURA:
                    return Infraestrutura();
                default:
                    return String.Empty;
            }
        }
        private static string Aplicacao()
        {
            return $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>MpsDefaultFramework</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>

    <!-- App root -->
    <Folder Include=""Models\"" />
    <Folder Include=""DTOs\"" />
    <Folder Include=""Interfaces\"" />
    <Folder Include=""UseCases\"" />
    <Folder Include=""Validators\"" />
    <Folder Include=""Mappers\"" />
    <Folder Include=""Services\"" />
    <Folder Include=""Handlers\"" />
    <Folder Include=""Globals\"" />

    <!-- Items -->
    <Folder Include=""Items\Media\"" />
    <Folder Include=""Items\Functions\"" />
    <Folder Include=""Items\Resources\"" />

    <!-- Data -->
    <Folder Include=""Data\Exceptions\"" />
    <Folder Include=""Data\Enums\"" />
    <Folder Include=""Data\Logs\"" />
    <Folder Include=""Data\Reports\"" />

  </ItemGroup>

</Project>";
        }

        private static string Dominio()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>MpsDefaultFramework</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>

    <!-- root -->
  <Folder Include=""Entities\"" />
  <Folder Include=""ValueObjects\"" />
  <Folder Include=""Aggregates\"" />
  <Folder Include=""Specifications\"" />
  <Folder Include=""Services\"" />
  <Folder Include=""Events\"" />
  <Folder Include=""EventHandlers\"" />
  <Folder Include=""Repositories\"" />
  <Folder Include=""Factories\"" />
  <Folder Include=""Exceptions\"" />
  <Folder Include=""Enums\"" />
  <Folder Include=""Policies\"" />
  </ItemGroup>

</Project>";
        }

        private static string Infraestrutura()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>MpsDefaultFramework</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include=""Persistence\Contexts\"" />
    <Folder Include=""Persistence\Repositories\"" />
    <Folder Include=""Persistence\Configurations\"" />
    <Folder Include=""Persistence\Migrations\"" />

    <Folder Include=""Configuration\Options\"" />
    <Folder Include=""Configuration\Bindings\"" />
    <Folder Include=""Configuration\Settings\"" />

    <Folder Include=""Logging\Providers\"" />
    <Folder Include=""Logging\Extensions\"" />

    <Folder Include=""Networking\Clients\"" />
    <Folder Include=""Networking\Handlers\"" />

    <Folder Include=""Messaging\Producers\"" />
    <Folder Include=""Messaging\Consumers\"" />

    <Folder Include=""Security\Encryption\"" />
    <Folder Include=""Security\Hashing\"" />
    <Folder Include=""Security\Tokens\"" />
    <Folder Include=""Security\Certificates\"" />

    <Folder Include=""Services\External\"" />
    <Folder Include=""Services\Notifications\"" />
    <Folder Include=""Services\Internal\"" />
    <Folder Include=""Services\Providers\"" />

    <Folder Include=""Storage\Files\"" />
    <Folder Include=""Storage\Local\"" />
    <Folder Include=""Storage\Remote\"" />

    <Folder Include=""Caching\Providers\"" />
    <Folder Include=""Caching\Extensions\"" />

    <Folder Include=""Common\Extensions\"" />
    <Folder Include=""Common\Helpers\"" />
    <Folder Include=""Common\Utils\"" />

    <Folder Include=""DependencyInjection\Modules\"" />
  </ItemGroup>

</Project>";
        }

        private static string ApresentacaoUi()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">
<PropertyGroup>
<TargetFramework>MpsDefaultFramework</TargetFramework>
</PropertyGroup>
 <ItemGroup>
    <Folder Include=""Views\"" />
    <Folder Include=""Models\"" />
</ItemGroup>
</Project>";
        }

        private static string ApresentacaoUif()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">
<PropertyGroup>
<TargetFramework>MpsDefaultFramework</TargetFramework>
</PropertyGroup>
 <ItemGroup>
    <Folder Include=""Views\"" />
    <Folder Include=""Models\"" />
</ItemGroup>
</Project>";
        }

        private static string ApresentacaoUiw()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>MpsDefaultFramework</TargetFramework>
    <UseWPF>true</UseWPF>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>

    <!-- ============================= -->
    <!-- VIEWS (XAML) -->
    <!-- ============================= -->

    <Folder Include=""Views\Windows\"" />
    <Folder Include=""Views\Pages\"" />
    <Folder Include=""Views\Dialogs\"" />
    <Folder Include=""Views\Controls\"" />
    <Folder Include=""Views\Layouts\"" />

    <!-- ============================= -->
    <!-- VIEWMODELS -->
    <!-- ============================= -->

    <Folder Include=""ViewModels\Windows\"" />
    <Folder Include=""ViewModels\Pages\"" />
    <Folder Include=""ViewModels\Dialogs\"" />
    <Folder Include=""ViewModels\Controls\"" />
    <Folder Include=""ViewModels\DesignTime\"" />

    <!-- ============================= -->
    <!-- MODELS (APENAS MODELOS DE UI) -->
    <!-- ============================= -->

    <Folder Include=""Models\ViewModelsState\"" />
    <Folder Include=""Models\UIModels\"" />
    <Folder Include=""Models\Navigation\"" />

    <!-- ============================= -->
    <!-- COMMANDS -->
    <!-- ============================= -->

    <Folder Include=""Commands\Base\"" />
    <Folder Include=""Commands\Async\"" />
    <Folder Include=""Commands\UI\"" />

    <!-- ============================= -->
    <!-- SERVICES DE APRESENTAÇÃO -->
    <!-- ============================= -->

    <Folder Include=""Services\Navigation\"" />
    <Folder Include=""Services\Dialogs\"" />
    <Folder Include=""Services\Notifications\"" />
    <Folder Include=""Services\Themes\"" />

    <!-- ============================= -->
    <!-- RESOURCES (XAML) -->
    <!-- ============================= -->

    <Folder Include=""Resources\Styles\"" />
    <Folder Include=""Resources\Themes\"" />
    <Folder Include=""Resources\Templates\"" />
    <Folder Include=""Resources\Icons\"" />
    <Folder Include=""Resources\Colors\"" />
    <Folder Include=""Resources\Fonts\"" />

    <!-- ============================= -->
    <!-- CONVERTERS -->
    <!-- ============================= -->

    <Folder Include=""Converters\"" />

    <!-- ============================= -->
    <!-- BEHAVIORS & ATTACHED PROPS -->
    <!-- ============================= -->

    <Folder Include=""Behaviors\"" />
    <Folder Include=""AttachedProperties\"" />

    <!-- ============================= -->
    <!-- VALIDATION -->
    <!-- ============================= -->

    <Folder Include=""Validation\Rules\"" />
    <Folder Include=""Validation\Errors\"" />

    <!-- ============================= -->
    <!-- NAVIGATION -->
    <!-- ============================= -->

    <Folder Include=""Navigation\Routes\"" />
    <Folder Include=""Navigation\ViewMappings\"" />

    <!-- ============================= -->
    <!-- COMMON / BASE -->
    <!-- ============================= -->

    <Folder Include=""Common\Base\"" />
    <Folder Include=""Common\Helpers\"" />
    <Folder Include=""Common\Extensions\"" />

  </ItemGroup>

</Project>
";
        }
    }
}
