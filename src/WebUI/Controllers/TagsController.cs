using Microsoft.AspNetCore.Mvc;
using Todo_App.Application.Tags.Commands.CreateTag;
using Todo_App.Application.Tags.Commands.DeleteTag;
using Todo_App.Application.Tags.Queries;
using Todo_App.Application.TodoLists.Queries.GetTodos;

namespace Todo_App.WebUI.Controllers;

public class TagsController : ApiControllerBase
{
    [HttpGet("tag")]
    public async Task<ActionResult<List<TagsDto>>> GetTags() 
    {
        var a = await Mediator.Send(new GetTagsQuery());
        return a;
    }

    [HttpPost()]
    public async Task<ActionResult<int>> CreateTag(CreateTagCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTag(int id)
    {
        await Mediator.Send(new DeleteTagCommand(id));

        return NoContent();
    }
}
