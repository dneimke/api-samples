namespace Api.Features.Todos;

public static class TodoEndpoints
{
    public static WebApplication MapTodoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/todos").WithTags("Todos");

        group.MapGet("", (ITodoService todoService) =>
        {
            return Results.Ok(todoService.GetAll());
        });

        group.MapGet("/{id:guid}", (Guid id, ITodoService todoService) =>
        {
            var item = todoService.GetById(id);
            return item is not null ? Results.Ok(item) : Results.NotFound();
        });

        group.MapPost("", (TodoItem todo, ITodoService todoService) =>
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
                return Results.BadRequest("Title is required.");

            todo.Id = Guid.NewGuid();
            todoService.Create(todo);
            return Results.Created($"/api/todos/{todo.Id}", todo);
        });

        group.MapPut("/{id:guid}", (Guid id, TodoItem todo, ITodoService todoService) =>
        {
            if (!todoService.Update(id, todo))
                return Results.NotFound();

            if (string.IsNullOrWhiteSpace(todo.Title))
                return Results.BadRequest("Title is required.");

            todo.Id = id;
            todoService.Update(id, todo);

            return Results.NoContent();
        });

        group.MapDelete("/{id:guid}", (Guid id, ITodoService todoService) =>
        {
            return todoService.Delete(id) ? Results.NoContent() : Results.NotFound();
        });

        return app;
    }
}
