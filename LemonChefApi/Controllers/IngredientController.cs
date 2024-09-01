using Application.Dto_s.Requests;
using Application.Dto_s.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class IngredientController : ControllerBase
{
    [HttpPost]
    public async Task<IngredientCreateResponse> CreateAsync([FromBody] IngredientCreateRequest request, 
        [FromServices] IngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.CreateAsync(request, cancellationToken);
        return result;
    }

    [HttpGet("{id:guid}")]
    public async Task<IngredientGetResponse> GetByIdAsync(Guid id, 
        [FromServices] IngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);
        return result;
    }

    [HttpPut]
    public async Task<IngredientUpdateResponse> UpdateAsync([FromBody] IngredientUpdateRequest request, [FromServices] IngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(request, cancellationToken);
        return result;
    }

    [HttpDelete ("{id:guid}")]

    public async Task<bool> DeleteAsync(Guid id, [FromServices] IngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(id, cancellationToken);
        return result;
    }
    
    [HttpGet]
    public async Task<List<IngredientGetResponse>> GetAsync([FromServices] IngredientService service, CancellationToken cancellationToken)
    {
        var result = await service.GetAllAsync(cancellationToken);
        return result;
    }
}