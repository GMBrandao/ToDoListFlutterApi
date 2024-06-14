namespace ToDoListFlutterApi.Model;

public class Tarefa
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public DateTime Hora { get; set; }
    public string? Descricao { get; set; }
    public string? Prioridade { get; set; }
    public bool Concluida { get; set; }
}