using Template.AppHost.Common;
using Template.AppHost.Common.Contants.Enums;


var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql", port: 1444)
                 .WithLifetime(ContainerLifetime.Persistent);

var templateDb = sql.AddDatabase("TemplateDb");


builder.AddProject<Projects.Template_API>(nameof(ServiceNameEnum.TemplateAPI))
    .WaitFor(templateDb)
    .WithReference(templateDb)
    ;

builder.AddProject<Projects.Template_HealthUI>(nameof(ServiceNameEnum.TemplateHealthUI))
    .WaitFor(templateDb)
    .WithReference(templateDb)
    ;

builder.Build().Run();
