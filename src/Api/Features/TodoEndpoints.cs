using System.Collections.Concurrent;

namespace Api.Features;

public static class TodoEndpoints
{
    private static readonly ConcurrentDictionary<Guid, TodoItem> Store = new();

    public static WebApplication MapTestEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/todos").WithTags("Todos");

        group.MapGet("", (HttpContext ctx) => Results.Ok(Store.Values));

        group.MapGet("/{id:guid}", (Guid id) =>
        {
            return Store.TryGetValue(id, out var item) ? Results.Ok(item) : Results.NotFound();
        });

        group.MapPost("", (TodoItem todo) =>
        {
            todo.Id = Guid.NewGuid();
            Store[todo.Id] = todo;
            return Results.Created($"/api/todos/{todo.Id}", todo);
        });

        group.MapPut("/{id:guid}", (Guid id, TodoItem todo) =>
        {
            if (!Store.ContainsKey(id)) return Results.NotFound();
            todo.Id = id;
            Store[id] = todo;
            return Results.NoContent();
        });

        group.MapDelete("/{id:guid}", (Guid id) =>
        {
            return Store.TryRemove(id, out _) ? Results.NoContent() : Results.NotFound();
        });

        return app;
    }
}
