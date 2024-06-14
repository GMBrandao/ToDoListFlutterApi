using Microsoft.AspNetCore.Mvc;
using ToDoListFlutterApi.Model;
using ToDoListFlutterApi.Services;

namespace ToDoListFlutterApi.Controllers;

[Route("api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TarefaService _tarefaService;

    public TaskController(TarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public ActionResult<List<Tarefa>> Get() => _tarefaService.Get();

    [HttpPost]
    public ActionResult<Tarefa> Create(Tarefa tarefa) => _tarefaService.Create(tarefa);
}