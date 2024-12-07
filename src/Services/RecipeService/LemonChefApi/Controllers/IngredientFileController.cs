using Application.Dto_s.LemonChefFile.FileData;
using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class IngredientFilesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        Guid IngredientId,
        Guid UserId,
        IFormFile file,
        [FromServices] IIngredientFileService service, CancellationToken cancellationToken = default)
    {
        var fileData = new FileDataDto(file.FileName, file.OpenReadStream(), file.ContentType);

        var request = new IngredientFileCreateRequest(IngredientId, UserId, fileData);

        var result = await service.AddAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IIngredientFileService service, CancellationToken cancellationToken = default)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);

        return File(result.FileData.Stream, result.FileData.ContentType, result.FileData.FileName);
    }

    [HttpPut]
    public IActionResult Update([FromBody] IngredientFileUpdateRequest request,
        [FromServices] IIngredientFileService service)
    {
        var result = service.Update(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IIngredientFileService service,
        CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}