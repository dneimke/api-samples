using System;

namespace Api.Features.Todos;

public class TodoItem
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}
