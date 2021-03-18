# Better project templates

![example workflow](https://github.com/AnthonyPWatts/ProjectTemplates/actions/workflows/dotnet.yml/badge.svg)

Leaning heavily on a [YouTube walkthrough](https://www.youtube.com/watch?v=GDNcxU0_OuE&ab_channel=MicrosoftVisualStudio) by [Sayed Hashimi (Senior Program Manager at Microsoft)](https://github.com/sayedihashimi), and the [supporting GitHub repo](https://github.com/sayedihashimi/template-sample) for templating and publishing steps.

## Templates
### [AnthonyPWatts.Templates.MVC](https://www.nuget.org/packages/AnthonyPWatts.Templates.MVC)
#### Published to NuGet.org
##### ASP.NET Core 3.1 Web App with Swagger and Serilog
Microsoft's ASP.NET MVC Core 3.1 Web App template, with:
* Swagger already wired up
* Serilog hooked up at Program.cs level, pulling config from appsettings
* appsettings.development.json set up for local logging
#### In Development
##### ASP.NET Core 3.1 Web API with swagger and Serilog
* ASP.NET Core 3.1 Web App template, with front end libraries etc. removed for a leaner package 
