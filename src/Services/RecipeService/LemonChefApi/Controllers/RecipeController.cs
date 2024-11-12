using System.Security.Claims;
using Application.Dto_s.Recipe.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;

namespace LemonChefApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RecipesController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] RecipeCreateRequest request,
        [FromServices] IRecipeService service, CancellationToken cancellationToken)
    {
        //TODO: добавить проверки и возвращение нужных кодов
        var userClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        TryParse(userClaim, out var userId);

        var result = await service.CreateAsync(request, userId, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IRecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId,
        [FromServices] IRecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetAllByUserIdAsync(userId, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{recipeId:guid}/ingredients")]
    public async Task<IActionResult> GetIngredientsByRecipeIdAsync(Guid recipeId,
        [FromServices] IRecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetRecipeIngredientsByRecipeId(recipeId, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromBody] RecipeUpdateRequest request,
        [FromServices] IRecipeService service, CancellationToken cancellationToken)
    {
        
        var userClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        TryParse(userClaim, out var userId);
        
        var result = await service.UpdateAsync(request, userId, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IRecipeService service,
        CancellationToken cancellationToken)
    {
        await service.DeleteByIdAsync(id, cancellationToken);
        return NoContent();
    }
}

//TODO: добавить выбор фильтра для всех контроллеров