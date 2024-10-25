using Domain.Entities.Base;
using Domain.Validations.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;

public class LemonChefFileValidator : AbstractValidator<LemonChefFile>
{
    public LemonChefFileValidator(string paramName)
    {
        RuleFor(param => param.UserId)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.UserId));
        
        RuleFor(param => param.FilePath)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.FilePath))
            .Must(Path.IsPathFullyQualified);

        RuleFor(param => param.FileName)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.FileName))
            .Length(2, 255).WithMessage(ExceptionMessages.InvalidFormat(nameof(LemonChefFile.FileName)));

        RuleFor(param => param.FileFormat)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.FileFormat))
            .IsInEnum().WithMessage(ExceptionMessages.InvalidEnumValue(nameof(LemonChefFile.FileFormat)));

        RuleFor(param => param.FileSizeInBytes)
            .NotNullOrEmptyWithMessage(nameof(LemonChefFile.FileSizeInBytes))
            .LessThanOrEqualTo(300 * 1024 * 1024);//TODO: добавить конфигурационный файл
    }
}