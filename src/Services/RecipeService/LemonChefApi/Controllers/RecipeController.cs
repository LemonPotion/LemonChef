using Application.Dto_s.Requests.Recipe;
using Application.Dto_s.Responses.Recipe;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RecipeController : ControllerBase
{
    [HttpPost]
    public async Task<RecipeCreateResponse> CreateAsync([FromBody] RecipeCreateRequest request, 
        [FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(request, cancellationToken);
        return result;
    }

    [HttpGet("{id:guid}")]
    public async Task<RecipeGetResponse> GetByIdAsync(Guid id, 
        [FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return result;
    }

    [HttpPut]
    public async Task<RecipeUpdateResponse> UpdateAsync([FromBody] RecipeUpdateRequest request, [FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(request, cancellationToken);
        return result;
    }

    [HttpDelete("{id:guid}")]
    public async Task<bool> DeleteAsync(Guid id, [FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(id, cancellationToken);
        return result;
    }
    
    [HttpGet]
    public async Task<List<RecipeGetResponse>> GetAsync([FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetAllAsync(cancellationToken);
        return result;
    }

    [HttpGet("tg/{id:int}")]
    public async Task<List<RecipeGetResponse>> GetAllByTelegramIdAsync(int id,[FromServices] RecipeService service, CancellationToken cancellationToken)
    {
        var result = await service.GetAllByTelegramIdAsync(id,cancellationToken);
        return result;
    }
}