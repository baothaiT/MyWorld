using MyWorld.AppHost.Common.Contants.Enums;
using MyWorld.AppHost.Common.Extensions;


var builder = DistributedApplication.CreateBuilder(args);
var configuration = ConfigurationExtension.GetConfigurations();

var sqlPassword = builder.AddParameter(
    name: "SqlServerPassword",
    configuration.GetSection("SqlServerPassword").Value ?? "",
    secret: true); // Maybe bug

var sql = builder.AddSqlServer(
    name: "sql",
    port: 1444,
    password: sqlPassword
    )
    .WithLifetime(ContainerLifetime.Persistent);

var MyWorldDb = sql.AddDatabase("MyWorldDb");

builder.AddProject<Projects.MyWorld_API>(nameof(ServiceNameEnum.MyWorldAPI))
    .WaitFor(MyWorldDb)
    .WithReference(MyWorldDb)
    ;

builder.AddProject<Projects.MyWorld_HealthUI>(nameof(ServiceNameEnum.MyWorldHealthUI))
    .WaitFor(MyWorldDb)
    .WithReference(MyWorldDb)
    ;

builder.Build().Run();
