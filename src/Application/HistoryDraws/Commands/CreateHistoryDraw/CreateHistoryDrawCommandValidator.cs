using FluentValidation;

namespace LotteryDraw.Application.TodoItems.Commands.CreateTodoItem;

public class CreateHistoryDrawCommandValidator : AbstractValidator<CreateHistoryDrawCommand>
{
    public CreateHistoryDrawCommandValidator()
    {
        RuleFor(hd => hd.FirstNumber).NotEmpty().WithMessage("First number has to be set");
        RuleFor(hd => hd.SecondNumber).NotEmpty().WithMessage("Second number has to be set");
        RuleFor(hd => hd.ThirdNumber).NotEmpty().WithMessage("Third number has to be set");
        RuleFor(hd => hd.FourthNumber).NotEmpty().WithMessage("Fourth number has to be set");
        RuleFor(hd => hd.FifthNumber).NotEmpty().WithMessage("Fifth number has to be set");
    }
}
