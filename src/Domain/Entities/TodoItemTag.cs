namespace Todo_App.Domain.Entities;
public class TodoItemTag : BaseAuditableEntity
{
    public string? TagName { get; set; }
   
    public List<TodoItem>? TodoItems { get; set; }
}
