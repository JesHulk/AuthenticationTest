var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AuthenticationTest_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.AuthenticationTest_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.AuthenticationTest_Api>("authenticationtest-api");

builder.Build().Run();
