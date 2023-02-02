using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo_App.Application.Common.Exceptions;
using Todo_App.Application.Common.Interfaces;
using Todo_App.Application.TodoLists.Queries.GetTodos;
using Todo_App.Domain.Entities;
using Todo_App.Domain.Enums;

namespace Todo_App.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? ColourCode { get; init; }

    public string? Note { get; init; }

    public List<TagsDto>? TodoItemTag { get; init; }
}

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .Include(x => x.TodoItemTag)
            .FirstOrDefaultAsync( x => x.Id == request.Id , cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        var tagIds = request.TodoItemTag?.Select(x => x.Id).ToList();
        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;
        entity.ColourCode = request.ColourCode;
        entity.TodoItemTag = await _context.TodoItemsTags.Where(x => tagIds.Contains(x.Id)).ToListAsync(cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
