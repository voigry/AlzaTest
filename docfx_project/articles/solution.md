# Řešení testovacího případu
> Tento projekt je řešením pro zadání Alza case study. Cílem je navrhnout plně automatizovanou test suitu pomocí .NET Core a C#. Běhové prostředí musí být
kompatibilní s CI/CD.
>
> ## Instalace
> Dle požadavků je test suita napsána pomocí .NET Core a C#, řešení používá .NET 6. Jako IDE bylo použito Visual Studio i VS Code. 
> 
> Visual Studio - instalace probíhá automaticky po otevření AlzaTest.sln
> 
> VS Code - je potřeba otevřít složku projektu -> Open Folder -> AlzaTest
> případně použít příkaz: 
> * run: dotnet build ./AlzaTest.sln
>
> Lokace na GitHubu https://github.com/voigry/AlzaTest.git
> ## CI/CD
> V průběhu vývoje byly využity GitHub akce. Projekt byl po každém commit do master sestaven a otestován v prostředí ubuntu s verzí .NET 5.0.x (viz main.yaml). 
> ## Jak spustit test
> Test lze spustit pomocí Nunit test runneru. Ve Visual Studiu použijeme Test Explorer. Ve VS Code je k dispozici doplněk .NET Test Explorer. Nebo lze jednoduše použít cli příkaz dotnet test, např: dotnet test --filter "FullyQualifiedName~AlzaTest.Tests.TestZadaniPositive"
>
> Na výběr je několik testů. Každý test rozšiřuje třídu AlzaBaseTest. Díky tomu je docíleno snadné rozšiřitelnosti o nové testy a znovu použitelnosti vlastností a metod. 
> ### Test pozice softwarový tester - positivní testování
> Spustí se pomocí příkazu: dotnet test --filter "FullyQualifiedName~AlzaTest.Tests.TestPositionSoftwareTesterPositive"
> Test obsahuje ověření hodnot pracovní pozice pozice, jako popis a jednotlivé položky pozice, lokace a s kým se aplikant potká na pohovoru.
> #### Možné chyby:
> U popisu pozice nesedí velká-malá písmena.
> ### Test pozice softwarový tester - negativní testování
> Spustí se pomocí příkazu: dotnet test --filter "FullyQualifiedName~AlzaTest.Tests.TestPositionSoftwareTesterNegative"
> Zde se testuje nevalidní country code a segment. V obou případech se očekává status odpovědi not found.
> #### Možné chyby:
> Při požití country kódu CzechiaCZ se očekává status odpovědi not found, aktuálně se ale vrací Ok.
>
> ## Struktura projektu
> Projekt je rozdělen do několika jmenných prostorů: Models, TestData, Tests a Logging
> 
> ### Models
> Obsahuje interfaces a implementační třídy k vytváření objektů z json obsahu odpovědí a k vytváření testovacích dat.
> 
> ### TestData
> Zde se nachází samotná testovací data. K plnění dat do testů je zejména využit TestCaseSource. V této ukázce jsou všechny data přístupná přes třídu JobTestCaseData a její property.
>
> ### Tests
> Jednotlivé testy včetně base testu se nachází zde.
>
> ### Logging
> Obsahuje implementaci logování.
> 
>## Logování
> Primárně se loguje se pomocí knihovny Log4net, zde je zejména využita možnost kontinuálního logování logů z různých testů do jednoho souboru. 
> ### Log4net
> Podrobné nastavení včetně nastavení cesty k logům se nachází v log4net.config. Samotná inicializace log4net je implementována ve třídě SetupTrace, kde se nastavuje cesta k log4net.config souboru a properta LogFileName, která nastavuje absolutní cestu k logovacímu souboru. Při nastavení těchto cest je brán ohled na nezávislost na operačním systému. Díky tomu, že je Log4net nastaven v kontextu OneTimeSetup je logger atutomaticky k dispozici ve všech testech nebo testFixtures a jednotlivé zápisy jsou zobrazeny při běhu v testovací konzoli (např. Test Explorer pro Visual Studio). 
> ### Trace a další Loggers
> Cesta k výsledkům a jiné vlastnosti Jsou nastaveny v runsettings. Výsledky testů jsou zapisovány do souboru html a trx. Je možno logovat i do console, nicméně tuto možnost ponechávám zakomentovanou.
