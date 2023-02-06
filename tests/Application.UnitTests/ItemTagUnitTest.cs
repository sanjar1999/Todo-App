using Moq;
using NUnit.Framework;
using Todo_App.Application.Tags.Queries;
using Todo_App.Application.TodoLists.Queries.GetTodos;
using Todo_App.WebUI.Controllers;

namespace Todo_App.Application.UnitTests;

[TestFixture]
public class ItemTagUnitTest
{
    private Mock<GetTagsQueryHandler>? _getTagsQueryHandler = new Mock<GetTagsQueryHandler>();
    private List<TagsDto>? entity;
    private GetTagsQuery? _getTagsQuery = new GetTagsQuery();

    [OneTimeSetUp]
    public void SetUp()
    {
        entity = new List<TagsDto>
        {
            new TagsDto
            {
                Id = 1,
                TagName = "item"
            }
        };

       _getTagsQueryHandler.Setup(x => x.Handle(_getTagsQuery, CancellationToken.None)).Returns(Task.FromResult(entity));
    }

    [Test]
    public void Handle_Should_GetAllTags()
    {
        var controller = new TagsController();
        var res = controller.GetTags();

        Assert.AreEqual(res, entity);
        Assert.NotNull(res);
    }
}
