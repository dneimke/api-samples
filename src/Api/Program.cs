using Api.Features;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/echo", (string? q) => Results.Ok(new { echo = q ?? "" }));

// Register feature endpoints
app.MapTestEndpoints();

app.Run();
