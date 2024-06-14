using Microsoft.Extensions.Options;
using ToDoListFlutterApi.Config;
using ToDoListFlutterApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "_myOrigins",
                       policy =>
                       {
                           policy.WithOrigins("*");
                       });
});
builder.Services.AddSwaggerGen();

builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("DBSettings"));
builder.Services.AddSingleton<IDBSettings>(s => s.GetRequiredService<IOptions<DBSettings>>().Value);
builder.Services.AddSingleton<TarefaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("_myOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();