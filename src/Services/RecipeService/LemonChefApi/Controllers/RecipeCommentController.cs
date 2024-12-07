using Application.Dto_s.Comment.RecipeComment.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class RecipeCommentsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] RecipeCommentCreateRequest request,
        [FromServices] IRecipeCommentService service, CancellationToken cancellationToken = default)
    {
        var result = await service.AddAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IRecipeCommentService service, CancellationToken cancellationToken = default)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult UpdateAsync([FromBody] RecipeCommentUpdateRequest request,
        [FromServices] IRecipeCommentService service)
    {
        var result = service.Update(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IRecipeCommentService service,
        CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}