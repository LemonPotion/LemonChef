using Application.Dto_s.Like.RecipeCommentLike.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class RecipeCommentLikesController : ControllerBase
{
    //TODO: проверить можно ли ставить много лайков от одного юзера
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] RecipeCommentLikeCreateRequest request,
        [FromServices] IRecipeCommentLikeService service, CancellationToken cancellationToken = default)
    {
        var result = await service.AddAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IRecipeCommentLikeService service, CancellationToken cancellationToken = default)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult UpdateAsync([FromBody] RecipeCommentLikeUpdateRequest request,
        [FromServices] IRecipeCommentLikeService service)
    {
        var result = service.Update(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IRecipeCommentLikeService service,
        CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}