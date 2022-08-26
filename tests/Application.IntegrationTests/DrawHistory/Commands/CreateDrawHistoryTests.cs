using LotteryDraw.Application.Common.Exceptions;
using LotteryDraw.Application.TodoItems.Commands.CreateTodoItem;
using LotteryDraw.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace LotteryDraw.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class CreateDrawHistoryTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateHistoryDrawCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateHistoryDraw()
    {

        var command = new CreateHistoryDrawCommand
        {
            FirstNumber = 1,
            SecondNumber = 2,
            ThirdNumber = 3,
            FourthNumber = 4,
            FifthNumber = 5
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<HistoryDraw>(1);

        item.Should().NotBeNull();
        item!.FirstNumber.Should().Be(command.FirstNumber);
        item.SecondNumber.Should().Be(command.SecondNumber);
        item.ThirdNumber.Should().Be(command.ThirdNumber);
        item.FourthNumber.Should().Be(command.FourthNumber);
        item.FifthNumber.Should().Be(command.FifthNumber);
    }
}
