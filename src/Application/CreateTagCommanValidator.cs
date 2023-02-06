using FluentValidation;
using Todo_App.Application.Tags.Commands.CreateTag;

namespace Todo_App.Application;
public class CreateTagCommanValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommanValidator()
    {
        RuleFor(v => v.TagName)
            .MaximumLength(15)
            .NotEmpty();
    }
}
