using System.Security.Claims;
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
        [FromServices] IIngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, 
        [FromServices] IIngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] IngredientUpdateRequest request, [FromServices] IIngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpDelete ("{id:guid}")]

    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IIngredientService service, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await service.DeleteByIdAsync(id, userId, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPagedAsync([FromQuery] IngredientGetAllPagedRequest pagedRequest ,[FromServices] IIngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.GetAllPagedAsync(pagedRequest.PageNumber,pagedRequest.PageSize,cancellationToken);
        return Ok(result);
    }
}