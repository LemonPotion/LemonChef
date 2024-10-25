using Domain.Entities.Base;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<Guid>, ITrackable, IViewable
{
    public ICollection<Recipe>? Recipes { get; set; }

    public ICollection<LemonChefFile>? UserFiles { get; set; }

    public ICollection<Like>? Likes { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedOn { get; set; }

    public long ViewCount { get; set; }
}