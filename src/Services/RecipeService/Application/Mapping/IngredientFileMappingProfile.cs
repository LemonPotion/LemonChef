using Application.Dto_s.LemonChefFile.IngredientFile.Requests;
using Application.Dto_s.LemonChefFile.IngredientFile.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class IngredientFileMappingProfile : Profile
{
    public IngredientFileMappingProfile()
    {
        CreateMap<IngredientFileCreateRequest, IngredientFile>()
            .ConstructUsing(dto => new IngredientFile()
            {
                UserId = dto.UserId,
                IngredientId = dto.IngredientId,
                Duration = dto.Duration,
                FileFormat = dto.FileFormat,
                FileName = dto.FileName,
                FileSizeInBytes = dto.FileSizeInBytes
            });

        CreateMap<IngredientFileUpdateRequest, IngredientFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<IngredientFile, IngredientFileCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<IngredientFile, IngredientFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<IngredientFile, IngredientFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));
    }
}