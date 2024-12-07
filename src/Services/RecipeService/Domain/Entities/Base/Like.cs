using Domain.Primitives;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities.Base;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; }

    public Like()
    {
    }

    public Like(Guid userId)
    {
        UserId = userId;

        var validator = new LikeValidator(nameof(Like));
        validator.ValidateAndThrow(this);
    }
}