using Application.Dto_s.LemonChefFile.FileData;
using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LemonChefApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class RecipeFilesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        Guid RecipeId,
        Guid UserId,
        IFormFile file,
        [FromServices] IFileService fileService,
        [FromServices] IRecipeFileService service,
        CancellationToken cancellationToken = default)
    {
        var fileData = new FileDataDto(file.FileName, file.OpenReadStream(), file.ContentType);

        var request = new RecipeFileCreateRequest(RecipeId, UserId, fileData);

        var response = await service.AddAsync(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id,
        [FromServices] IRecipeFileService service, CancellationToken cancellationToken = default)
    {
        var result = await service.GetByIdAsync(id, cancellationToken);

        return File(result.FileData.Stream, result.FileData.ContentType, result.FileData.FileName);
    }

    [HttpPut]
    public IActionResult UpdateAsync([FromBody] RecipeFileUpdateRequest request,
        [FromServices] IRecipeFileService service)
    {
        var result = service.Update(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IRecipeFileService service,
        CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(id, cancellationToken);
        return NoContent();
    }
}