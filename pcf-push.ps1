& cd .\PingApi
& cf push
& cd ..\PingService
& cf push
& cd ..\PongApi
& cf push
& cd ..\PongService
& cf push
		
& cd ..\WebApp
& cf push

& cd ..