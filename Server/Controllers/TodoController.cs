using Microsoft.AspNetCore.Mvc;
using TodoApp.Shared;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService _todoService;

    private readonly IGuidGeneratorService _guidGeneratorService;

    public TodoController(ITodoService todoService, ILogger<TodoController> logger)
    {
        _todoService = todoService;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<TodoItem> Get()
    {  
        return _todoService.GetAll();
    }

    [HttpPost]
    public void Post(TodoItem item) {
        _todoService.Add(item);
    }

    [HttpDelete("{itemId}")]
    public void Delete(Guid itemId) {
        _todoService.Delete(itemId);
    }

    [HttpPost("complete")]
    public void Complete(TodoItem item)
    {
        _todoService.Complete(item);
    }

    [HttpPost("uncomplete")]
    public void Uncomplete(TodoItem item)
    {
        _todoService.Uncomplete(item);
    }
    // public IActionResult Index()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
