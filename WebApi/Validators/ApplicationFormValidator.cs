using FluentValidation;
using Services.Contracts;
namespace WebApi.Validators;

/// <summary>
/// добавляем правила валидации для ДТО
/// </summary>
public class ApplicationFormValidator: AbstractValidator<ApplicationFormDto>
{
    public ApplicationFormValidator()
    {
        RuleFor(dto => dto.FirstName).NotEmpty()
            .MaximumLength(255);
        RuleFor(dto => dto.SecondName).NotEmpty()
            .MaximumLength(255);
        RuleFor(dto => dto.LastName).NotEmpty()
          .MaximumLength(255);
        RuleFor(dto => dto.Inn).NotEmpty()
         .MaximumLength(255);
    }
}
