namespace ToDoListFlutterApi.Config;

public interface IDBSettings
{
    string CollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}