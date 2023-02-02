using MediatR;
using Todo_App.Application.Common.Interfaces;
using Todo_App.Domain.Entities;

namespace Todo_App.Application.Tags.Commands.CreateTag;

public record CreateTagCommand : IRequest<int>
{
    public string? TagName { get; init; }
}
public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTagCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItemTag
        {
            TagName = request.TagName,
            Created = DateTime.UtcNow,
        };

        _context.TodoItemsTags.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
