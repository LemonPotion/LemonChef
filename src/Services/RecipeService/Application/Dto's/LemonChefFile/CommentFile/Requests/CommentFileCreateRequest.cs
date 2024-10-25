using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.LemonChefFile.CommentFile.Requests;

public class CommentFileCreateRequest : BaseLemonChefFileDto
{
    public IFormFile File { get; set; }
}