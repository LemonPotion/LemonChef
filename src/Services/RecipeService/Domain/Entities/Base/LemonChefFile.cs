using Domain.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities.Base;

public class LemonChefFile : BaseEntity
{
    //TODO: придумать ограничение по формату файла
    public Guid UserId { get; set; }

    public User User { get; set; }

    public string GoogleDriveName { get; set; }
    
    public string OriginalName { get; set; }

    public LemonChefFile()
    {
    }

    public LemonChefFile(Guid userId, string googleDriveName)
    {
        GoogleDriveName = googleDriveName;
        UserId = userId;
        var validator = new LemonChefFileValidator(nameof(LemonChefFile));
        validator.ValidateAndThrow(this);
    }
}