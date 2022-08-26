using LotteryDraw.Application.Common.Mappings;
using LotteryDraw.Domain.Entities;

namespace LotteryDraw.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class HistoryDrawDto : IMapFrom<HistoryDraw>
{
    public DateTime DrawTime { get; set; }
    public byte FirstNumber { get; set; }
    public byte SecondNumber { get; set; }
    public byte ThirdNumber { get; set; }
    public byte FourthNumber { get; set; }
    public byte FifthNumber { get; set; }
}
