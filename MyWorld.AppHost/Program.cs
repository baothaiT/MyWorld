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

var myWorldAPI = builder.AddProject<Projects.MyWorld_API>(nameof(ServiceNameEnum.MyWorldAPI))
    .WaitFor(MyWorldDb)
    .WithReference(MyWorldDb)
    ;

builder.AddProject<Projects.MyWorld_HealthUI>(nameof(ServiceNameEnum.MyWorldHealthUI))
    .WaitFor(MyWorldDb)
    .WithReference(MyWorldDb)
    ;

// React UI
// Provide the correct path to the npm executable or use a valid overload
builder.AddExecutable("react-ui", "npm", workingDirectory: "../MyWorld.AdminUI/myworld-dashboard")
    .WithArgs("start")
    .WithHttpEndpoint(port: 3001, name: "http") // React dev server default
    .WaitFor(myWorldAPI)
    .WithReference(myWorldAPI);

builder.Build().Run();
