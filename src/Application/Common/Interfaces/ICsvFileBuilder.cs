using Todo_App.Application.TodoLists.Queries.ExportTodos;

namespace Todo_App.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
