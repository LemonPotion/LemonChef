using Application.Dto_s.Ingredient.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class IngredientsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] IngredientCreateRequest request,
        [FromServices] IIngredientService service, CancellationToken cancellationToken = default)
    {
        var result = await service.AddAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IIngredientService service, CancellationToken cancellationToken = default)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public IActionResult UpdateAsync([FromBody] IngredientUpdateRequest request,
        [FromServices] IIngredientService service)
    {
        var result = service.Update(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IIngredientService service,
        CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}