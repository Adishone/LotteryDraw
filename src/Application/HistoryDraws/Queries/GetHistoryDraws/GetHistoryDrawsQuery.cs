using AutoMapper;
using AutoMapper.QueryableExtensions;
using LotteryDraw.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LotteryDraw.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetHistoryDrawsQuery : IRequest<List<HistoryDrawDto>>
{

}

public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetHistoryDrawsQuery, List<HistoryDrawDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<HistoryDrawDto>> Handle(GetHistoryDrawsQuery request, CancellationToken cancellationToken)
    {
        return await _context.DrawHistory
            .OrderBy(dh => dh.DrawTime)
            .ProjectTo<HistoryDrawDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
