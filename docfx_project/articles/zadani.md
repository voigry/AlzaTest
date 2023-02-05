# Zadání:
> Navrhnout plně automatizovanou test suitu pomocí .NET Core a C#. Běhové prostředí
kompatibilní s CI/CD.
## Scope:
> na stránkách www.alza.cz/kariera chceme najit inzerát na pozici software
tester pro QA odděleni, kde zkontrolujme, že inzerát obsahuje všechny potřebné informace pro
kandidáta k pohovoru. (vyplněný popis pozice, fotka lidi, které potkáte na pohovoru a jejich krátký
popisek...).  
### Máme veřejný end point
https://webapi.alza.cz/api/career/v2/positions/softwarovy-tester?country=cz
## Zjistit výsledek:
* Vyplněný popis pozice
* Kde bude pracovat
* S kým se na pohovoru setká a co se o něm doví.
* Jestli je to práce pro studenty
## Požadavky:(Pokuste se dodržet zadání, doporučené je splnit všechny, není však povinné)
* Řešení je verzováno pomocí Gitu uloženo na GitHub a spustitelné
* Řešení používá .NET 5.0
* Řešení používá NUnit jako test runner
* Řešení používá REST API klient library RestSharp
* Doporučený nástroj pro vývoj je IDE - VS Code
* Řešení je zdokumentováno pomoci automaticky generované dokumentace (docfx)
* Řešení nabízí config, ve kterém je možné definovat cesty k logům
* Řešení podporuje logování pro snadnější debug a
* reportováni. Logovaní průběhu testu
* Ověřit zachycení neplatného url segmentu. Např: jiná prac. pozice, jazyk 