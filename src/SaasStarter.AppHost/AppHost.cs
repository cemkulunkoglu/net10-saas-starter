var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(isReadOnly: false);

var appdb = postgres.AddDatabase("appdb");

builder.AddProject<Projects.SaasStarter_Api>("api")
    .WithReference(appdb)
    .WaitFor(appdb);

builder.Build().Run();
