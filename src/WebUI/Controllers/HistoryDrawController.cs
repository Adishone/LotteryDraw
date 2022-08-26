using LotteryDraw.Application.TodoItems.Commands.CreateTodoItem;
using LotteryDraw.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace LotteryDraw.WebUI.Controllers;

public class HistoryDrawController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<HistoryDrawDto>>> GetHistoryDraws([FromQuery] GetHistoryDrawsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateHistoryDrawCommand command)
    {
        return await Mediator.Send(command);
    }
}
