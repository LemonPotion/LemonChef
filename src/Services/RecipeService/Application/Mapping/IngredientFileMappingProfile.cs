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
            .ConstructUsing((dto, context) => new IngredientFile()
            {
                UserId = dto.UserId,
                IngredientId = dto.IngredientId,
                OriginalName = dto.FileData.FileName
            });

        CreateMap<IngredientFileUpdateRequest, IngredientFile>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.GoogleDriveName, opt => opt.Ignore());

        CreateMap<IngredientFile, IngredientFileCreateResponse>()
            .ConstructUsing(file => new IngredientFileCreateResponse(
                file.Id,
                file.IngredientId,
                file.UserId, 
                file.GoogleDriveName));
        CreateMap<IngredientFile, IngredientFileUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId));

        CreateMap<IngredientFile, IngredientFileGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.FileData, opt => opt.Ignore());
    }
}