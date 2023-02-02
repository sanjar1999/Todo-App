using FluentValidation;

namespace Todo_App.Application.Tags.Commands.CreateTag;
public class CreateTagCommanValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommanValidator()
    {
        RuleFor(v => v.TagName)
            .MaximumLength(15)
            .NotEmpty();
    }
}
