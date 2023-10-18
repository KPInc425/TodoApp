using TodoApp.Shared;

namespace Server.Services;

public class TodoService : ITodoService
{
    private readonly IList<TodoItem> _items;

    public TodoService()
    {
        _items = new List<TodoItem> {
            new TodoItem("Practice Blazor"),
            new TodoItem("Add some Todo's"),
        };
    }

    public IEnumerable<TodoItem> GetAll()
    {
        return _items.ToList();
    }

    public void Add(TodoItem item)
    {
        _items.Add(item);
    }

    public void Delete(Guid itemId)
    {
        var todoItem = _items.Single(x => x.Id == itemId);
        _items.Remove(todoItem);
    }

    public void Complete(TodoItem item)
    {
        var todoItem = _items.Single(i => i.Id == item.Id);
        todoItem.Completed = true;
    }

    public void Uncomplete(TodoItem item)
    {
        var todoItem = _items.Single(i => i.Id == item.Id);
        todoItem.Completed = false;
    }
}

