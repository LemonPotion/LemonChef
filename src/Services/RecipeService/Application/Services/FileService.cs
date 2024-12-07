using Application.Dto_s.LemonChefFile.FileData;
using Application.Interfaces.Services;
using Application.Settings;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class FileService : IFileService
{
    private readonly StorageClient _storageClient;
    private readonly GoogleSettings _googleSettings;

    public FileService(StorageClient storageClient, IOptions<GoogleSettings> googleSettings)
    {
        _storageClient = storageClient;
        _googleSettings = googleSettings.Value;
    }

    public async Task<string> UploadFileAsync(FileDataDto fileData, CancellationToken cancellationToken = default)
    {
        var googleName = Guid.NewGuid().ToString();
        var file = await _storageClient.UploadObjectAsync(_googleSettings.BucketName, googleName,
            fileData.ContentType, fileData.Stream, cancellationToken: cancellationToken);
        return googleName;
    }

    public async Task DeleteFileAsync(string id, CancellationToken cancellationToken = default)
    {
        var file = await _storageClient.GetObjectAsync(_googleSettings.BucketName, id,
            cancellationToken: cancellationToken);

        var request = _storageClient.DeleteObjectAsync(file, cancellationToken: cancellationToken);
    }

    public async Task<FileDataDto> DownloadFileAsync(string id, string originalName, CancellationToken cancellationToken = default)
    {
        var cloudFile =
            await _storageClient.GetObjectAsync(_googleSettings.BucketName, id, cancellationToken: cancellationToken);

        var stream = new MemoryStream();

        var file = await _storageClient.DownloadObjectAsync(cloudFile, stream,
            cancellationToken: cancellationToken);

        stream.Position = 0;

        return new FileDataDto(originalName, stream, file.ContentType);
    }
}