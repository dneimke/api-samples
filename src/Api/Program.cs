using Api.Features;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // .NET 9 built-in OpenAPI support
builder.Services.AddSingleton<ITodoService, TodoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Map the OpenAPI JSON generator and the UI. MapOpenApi will register the
    // endpoint that serves the OpenAPI document at `/openapi/v1.json` by default.
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        // Point the UI to the new Microsoft-generated JSON file
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/echo", (string? q) => Results.Ok(new { echo = q ?? "" }));

// Register feature endpoints
app.MapTodoEndpoints();

app.Run();
