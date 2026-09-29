var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServer("sqlserver")
    .WithDataVolume()
    .AddDatabase("LocalConnection");

builder.AddProject<Projects.Microservice_Api>("microservice-api")
    .WithReference(database)
    .WithExternalHttpEndpoints();

builder.Build().Run();
