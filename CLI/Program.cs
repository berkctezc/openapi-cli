var builder = CoconaApp.CreateBuilder();
var services = builder.Services;

services.AddServices();

var app = builder.Build();

app.AddCommands();

app.Run();