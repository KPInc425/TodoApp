using TodoApp.Shared;

namespace Server.Services;

public interface ITodoService
{
    public IEnumerable<TodoItem> GetAll();
    public void Add(TodoItem item);
    public void Delete(Guid itemId);
    public void Complete(TodoItem item);
    public void Uncomplete(TodoItem item);
}
