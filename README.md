# microservice-sample

## configuration variables

### PingApi

1. NServiceBusLicensePath **(i.e. c:\dev\NSBLicense.xml)**
2. RabbitMQConnectionString **(defaults to 60 seconds)**
3. PingApiUseUrls **(i.e. http://*:19701)**

### PingService

1. MongoDbConnectionString
2. NServiceBusLicensePath **(i.e. c:\dev\NSBLicense.xml)** 
3. RabbitMQConnectionString **(defaults to 60 seconds)** 

### PongApi

1. NServiceBusLicensePath **(i.e. c:\dev\NSBLicense.xml)**
2. RabbitMQConnectionString **(defaults to 60 seconds)**
3. PongApiUseUrls **(i.e. http://*:19702)** 

### PongService

1. MongoDbConnectionString
2. NServiceBusLicensePath **(i.e. c:\dev\NSBLicense.xml)** 
3. PongServiceTimeoutThresholdSeconds
4. RabbitMQConnectionString **(defaults to 60 seconds)** 

### WebApp

1. MongoDbConnectionString
2. NServiceBusLicensePath **(i.e. c:\dev\NSBLicense.xml)**
3. RabbitMQConnectionString **(defaults to 60 seconds)**
4. WebAppPingUrl **(i.e. http://localhost:19701/api/ping)**
5. WebAppPongUrl **(i.e. http://localhost:19702/api/pong)**


