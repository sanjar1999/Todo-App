using System.Globalization;
using CsvHelper.Configuration;
using Todo_App.Application.TodoLists.Queries.ExportTodos;

namespace Todo_App.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
