using Domain.Validations.Primitives;
using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.LemonChefFile;

public class BaseLemonChefFileDto
{
    public Guid UserId { get; set; }

    public IFormFile File { get; set; }
}