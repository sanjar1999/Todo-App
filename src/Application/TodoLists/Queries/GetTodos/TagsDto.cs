using Todo_App.Application.Common.Mappings;
using Todo_App.Domain.Entities;

namespace Todo_App.Application.TodoLists.Queries.GetTodos;
public class TagsDto :  IMapFrom<TodoItemTag>
{
    public int? Id { get; set; }
    public string? TagName { get; set; }
}
