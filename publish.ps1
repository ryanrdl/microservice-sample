param(
    [string] $configuration = "Release",
    [string] $webAppOutDir = ""
)

& (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") .\WebApp\WebApp.csproj /p:Configuration=$configuration /p:OutDir=$webAppOutDir

dotnet publish .\PingApi -o c:\output\PingApi -c $configuration -r active
dotnet publish .\PingService -o c:\output\PingService -c $configuration -r active
dotnet publish .\PongApi -o c:\output\PongApi -c $configuration -r active
dotnet publish .\PongService -o c:\output\PongService -c $configuration -r active