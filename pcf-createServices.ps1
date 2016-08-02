& cf create-service p-rabbitmq standard pingpongrabbitmq
& cf create-user-provided-service pingpong-mlab-mongodb -p "MongoDbConnectionString"
