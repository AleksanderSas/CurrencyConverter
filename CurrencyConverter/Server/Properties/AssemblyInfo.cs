using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Ogólne informacje o zestawie są kontrolowane poprzez następujący 
// zestaw atrybutów. Zmień wartości tych atrybutów, aby zmodyfikować informacje
// powiązane z zestawem.
[assembly: AssemblyTitle("Server")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Server")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("dd89b963-b174-4774-a140-ca3722007a2e")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Logger/log4net.config")]

[assembly: InternalsVisibleTo("CurrencyServiceTest")]