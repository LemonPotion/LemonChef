using Application.Dto_s.Like.RecipeLike.Requests;
using Application.Dto_s.Like.RecipeLike.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RecipeLikeMappingProfile : Profile
{
    public RecipeLikeMappingProfile()
    {
        CreateMap<RecipeLikeCreateRequest, RecipeLike>()
            .ConstructUsing(dto => new RecipeLike()
            {
                UserId = dto.UserId,
                RecipeId = dto.RecipeId
            });

        CreateMap<RecipeLikeUpdateRequest, RecipeLike>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId));

        CreateMap<RecipeLike, RecipeLikeCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId));


        CreateMap<RecipeLike, RecipeLikeUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId));


        CreateMap<RecipeLike, RecipeLikeGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId));
    }
}