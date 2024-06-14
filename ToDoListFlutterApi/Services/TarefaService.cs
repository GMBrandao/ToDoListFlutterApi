using MongoDB.Driver;
using ToDoListFlutterApi.Config;
using ToDoListFlutterApi.Model;

namespace ToDoListFlutterApi.Services;

public class TarefaService
{
    private readonly IMongoCollection<Tarefa> _task;

    public TarefaService(IDBSettings settings)
    {
        var customer = new MongoClient(settings.ConnectionString);
        var database = customer.GetDatabase(settings.DatabaseName);
        _task = database.GetCollection<Tarefa>(settings.CollectionName);
    }

    public List<Tarefa> Get() => _task.Find(c => true).ToList();

    public Tarefa Create(Tarefa tarefa)
    {
        tarefa.Id = Guid.NewGuid();
        _task.InsertOne(tarefa);
        return tarefa;
    }
}