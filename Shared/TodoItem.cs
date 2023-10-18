namespace TodoApp.Shared;

public class TodoItem
{
    public TodoItem(string text)
    {
        Text = text;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; }
    public bool Completed { get; set; }
}

