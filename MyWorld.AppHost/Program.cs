using MyWorld.AppHost.Common;
using MyWorld.AppHost.Common.Contants.Enums;


var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql", port: 1444)
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
