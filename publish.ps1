param(
    [string] $configuration = "Release",
    [string] $webAppPublishUrl = ""
)

& (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") .\WebApp\WebApp.csproj /t:WebPublish /p:Configuration=$configuration /p:WebPublishMethod=FileSystem /p:publishUrl=$webAppPublishUrl


dotnet publish .\PingApi -o c:\output\PingApi -c $configuration -r active
dotnet publish .\PingService -o c:\output\PingService -c $configuration -r active
dotnet publish .\PongApi -o c:\output\PongApi -c $configuration -r active
dotnet publish .\PongService -o c:\output\PongService -c $configuration -r active