namespace Application.Dto_s.LemonChefFile.FileData;

public record FileDataDto(
    string FileName, 
    Stream Stream,
    string ContentType);