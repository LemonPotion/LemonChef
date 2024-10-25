using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.LemonChefFile.CommentFile.Requests;

public class CommentFileUpdateRequest : BaseLemonChefFileDto
{
    public Guid Id { get; set; }
}