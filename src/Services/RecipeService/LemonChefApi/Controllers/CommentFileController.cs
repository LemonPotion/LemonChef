using Application.Dto_s.LemonChefFile.CommentFile.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class CommentFilesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CommentFileCreateRequest request,
        [FromServices] ICommentFileService service, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] ICommentFileService service, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] CommentFileUpdateRequest request,
        [FromServices] ICommentFileService service, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] ICommentFileService service,
        CancellationToken cancellationToken)
    { 
        await service.DeleteByIdAsync(id, cancellationToken);
        return NoContent();
    }
}