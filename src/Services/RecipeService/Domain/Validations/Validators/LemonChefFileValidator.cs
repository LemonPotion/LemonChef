using Domain.Entities.Base;
using FluentValidation;

namespace Domain.Validations.Validators;

public class LemonChefFileValidator : AbstractValidator<LemonChefFile>
{
    public LemonChefFileValidator(string paramName)
    {
        RuleFor(param => param.UserId)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.UserId));

        RuleFor(param => param.GoogleDriveName)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.GoogleDriveName));
        //TODO: добавить конфигурационный файл
    }
}