var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var tasks = new List<TaskItem>
{
    new TaskItem { Id = 1, Title = "SAD Project", IsComplete = false },
    new TaskItem { Id = 2, Title = "CN Project", IsComplete = false }
};




app.MapGet("/api/tasks", () =>
{
    return Results.Ok(tasks);
})
.WithName("GetAll").WithSummary("Returns all tasks").WithTags("ToDoApp");


app.MapGet("/api/tasks/{id}", (int id) =>
{
    if (tasks.Exists(t => t.Id == id))
    {
        return Results.Ok(tasks.Find(t => t.Id == id));
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("GetOne").WithSummary("Finds a task by id").WithTags("ToDoApp");

app.MapPost("/api/tasks/", (TaskItem taskItem) => {
    tasks.Add(taskItem);
    return Results.Created($"api/tasks/{taskItem.Id}", taskItem);
})
.WithName("AddOne").WithSummary("Adds a task item").WithTags("ToDoApp");

app.MapPut("/api/tasks/{id}", (int id, TaskItem newTaskItem) => {
    if (tasks.Exists(t => t.Id == id))
    {
        int index = tasks.FindIndex(t => t.Id == id);
        tasks[index] = newTaskItem;
        return Results.Ok(tasks[index]);
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("UpdateTask").WithSummary("Updates an already existing task").WithTags("ToDoApp");

app.MapDelete("/api/tasks/{id}", (int id) => {
    if (tasks.Exists(t => t.Id == id))
    {
        tasks.RemoveAll(t => t.Id == id);
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
})
.WithName("Remove").WithSummary("Removes all with matching ID").WithTags("ToDoApp");

app.Run();

public class TaskItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public DateTime? DueDate { get; set; }
}
