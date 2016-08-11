param( 
	[string] $configuration = "Debug",
	[string] $framework = "net451",
	[string] $platform = "win7-x64"			
)

$msbuild = (Resolve-Path "C:\Program Files (x86)\MSBuild\*\Bin\MSBuild.exe") 

& $msbuild .\PingApi\PingApi.csproj /p:Configuration=$configuration /t:Build
& $msbuild .\PongApi\PongApi.csproj /p:Configuration=$configuration /t:Build
& $msbuild .\PingService\PingService.csproj /p:Configuration=$configuration /t:Build
& $msbuild .\PongService\PongService.csproj /p:Configuration=$configuration  /t:Build
& $msbuild .\WebApp2\WebApp2.csproj /p:Configuration=$configuration /t:Build

& cmd /c start .\PingApi\bin\$configuration\$framework\$platform\PingApi.exe --server.urls=http://0.0.0.0:19701
& cmd /c start .\PongApi\bin\$configuration\$framework\$platform\PongApi.exe --server.urls=http://0.0.0.0:19702
& cmd /c start .\PingService\bin\$configuration\$framework\$platform\PingService.exe
& cmd /c start .\PongService\bin\$configuration\$framework\$platform\PongService.exe
& cmd /c start .\WebApp2\bin\$configuration\WebApp2.exe
 