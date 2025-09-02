using System.Collections.Concurrent;

namespace Api.Features.Todos;

public interface ITodoService
{
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(Guid id);
    TodoItem Create(TodoItem todo);
    bool Update(Guid id, TodoItem todo);
    bool Delete(Guid id);
}

public class TodoService : ITodoService
{
    private readonly ConcurrentDictionary<Guid, TodoItem> _store = new();

    public IEnumerable<TodoItem> GetAll() => _store.Values;

    public TodoItem? GetById(Guid id) => _store.TryGetValue(id, out var item) ? item : null;

    public TodoItem Create(TodoItem todo)
    {
        if (string.IsNullOrWhiteSpace(todo.Title))
            throw new ArgumentException("Title is required.", nameof(todo));

        todo.Id = Guid.NewGuid();
        _store[todo.Id] = todo;
        return todo;
    }

    public bool Update(Guid id, TodoItem todo)
    {
        if (!_store.ContainsKey(id)) return false;

        if (string.IsNullOrWhiteSpace(todo.Title))
            throw new ArgumentException("Title is required.", nameof(todo));

        todo.Id = id;
        _store[id] = todo;
        return true;
    }

    public bool Delete(Guid id) => _store.TryRemove(id, out _);
}