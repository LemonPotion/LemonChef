using Application.Dto_s.LemonChefFile.RecipeFile.Requests;
using Application.Dto_s.LemonChefFile.RecipeFile.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RecipeFileMappingProfile : Profile
{
    public RecipeFileMappingProfile()
    {
        CreateMap<RecipeFileCreateRequest, RecipeFile>()
            .ConstructUsing(dto => new RecipeFile()
            {
                UserId = dto.UserId,
                RecipeId = dto.RecipeId,
                Duration = dto.Duration,
                FileFormat = dto.FileFormat,
                FileName = dto.FileName,
                FileSizeInBytes = dto.FileSizeInBytes
            });

        CreateMap<RecipeFileUpdateRequest, RecipeFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<RecipeFile, RecipeFileCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<RecipeFile, RecipeFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));

        CreateMap<RecipeFile, RecipeFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.FileFormat, opt => opt.MapFrom(src => src.FileFormat))
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.FileSizeInBytes));
    }
}