using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo_App.Application.Common.Interfaces;
using Todo_App.Application.TodoLists.Queries.GetTodos;

namespace Todo_App.Application.Tags.Queries;
public record GetTagsQuery : IRequest<List<TagsDto>>;

public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, List<TagsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTagsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TagsDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoItemsTags
                .AsNoTracking()
                .ProjectTo<TagsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    }
}
