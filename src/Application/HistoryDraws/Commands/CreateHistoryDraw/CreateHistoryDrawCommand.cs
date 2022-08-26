using LotteryDraw.Application.Common.Interfaces;
using LotteryDraw.Domain.Entities;
using MediatR;

namespace LotteryDraw.Application.TodoItems.Commands.CreateTodoItem;

public record CreateHistoryDrawCommand : IRequest<int>
{
    public byte FirstNumber { get; set; }
    public byte SecondNumber { get; set; }
    public byte ThirdNumber { get; set; }
    public byte FourthNumber { get; set; }
    public byte FifthNumber { get; set; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateHistoryDrawCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateHistoryDrawCommand request, CancellationToken cancellationToken)
    {
        var entity = new HistoryDraw
        {
            DrawTime = DateTime.Now,
            FirstNumber = request.FirstNumber,
            SecondNumber = request.SecondNumber,
            ThirdNumber = request.ThirdNumber,
            FourthNumber = request.FourthNumber,
            FifthNumber = request.FifthNumber
        };

        _context.DrawHistory.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
