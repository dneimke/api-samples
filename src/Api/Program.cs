using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/echo", (string? q) => Results.Ok(new { echo = q ?? "" }));

app.MapGet("/ai/instructions", () =>
{
    var repoRoot = AppContext.BaseDirectory;
    // ai files will be copied to output in dev/run scenarios; try a few relative locations
    var candidates = new[]
    {
        Path.Combine(repoRoot, "ai", "copilot-instructions.md"),
        Path.Combine(repoRoot, "..", "..", "..", "ai", "copilot-instructions.md")
    };

    foreach (var path in candidates)
    {
        if (File.Exists(path))
        {
            var text = File.ReadAllText(path);
            return Results.Text(text, "text/markdown");
        }
    }

    return Results.NotFound();
});

app.Run();
