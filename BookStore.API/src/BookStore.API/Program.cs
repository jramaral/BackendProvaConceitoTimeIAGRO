using BookStore.API.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ResolveDependencies(builder.Configuration);

builder.Services.AddApiConfig();

var app = builder.Build();

app.UseApiConfig(app.Environment);

app.Run();
