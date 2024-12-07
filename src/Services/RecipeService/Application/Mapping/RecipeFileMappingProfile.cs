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
                OriginalName = dto.FileData.FileName
            });

        CreateMap<RecipeFileUpdateRequest, RecipeFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.GoogleDriveName, opt => opt.Ignore());

        CreateMap<RecipeFile, RecipeFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId));

        CreateMap<RecipeFile, RecipeFileCreateResponse>()
            .ConstructUsing(file => new RecipeFileCreateResponse(
                file.Id,
                file.RecipeId,
                file.UserId, 
                file.GoogleDriveName));

        CreateMap<RecipeFile, RecipeFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.FileData, opt => opt.Ignore());
    }
}