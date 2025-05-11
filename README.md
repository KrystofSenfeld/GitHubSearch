# GitHubSearch

A demo .NET Framework MVC web application showcasing the ability to search GitHub users and their repos through the GitHub API.

The site can be accessed here: https://githubsearchdemo.azurewebsites.net/.

## Setup
The code can be checked out by cloning the repository in Visual Studio.

Ensure that the following are installed:
- [.NET Framework 4.8.1 Developer Pack](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)

## TODO
- Refactor business logic out of controllers, perhaps into a separate class library.
- Check if there is a better way to use HttpClient -- IHttpClientFactory unavailable?
- Rather than using the CDN, it would be better to use the source files so that we can better customize and compile any desired changes.