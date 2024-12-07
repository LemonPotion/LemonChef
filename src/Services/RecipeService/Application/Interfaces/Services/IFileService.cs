using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс для работы с файлами в приложении.
/// </summary>
public interface IFileService
{
    Task<string> UploadFileAsync(FileDataDto fileData, CancellationToken cancellationToken = default);

    public Task DeleteFileAsync(string id, CancellationToken cancellationToken = default);

    public Task<FileDataDto> DownloadFileAsync(string id, string originalNam, CancellationToken cancellationToken = default);
}