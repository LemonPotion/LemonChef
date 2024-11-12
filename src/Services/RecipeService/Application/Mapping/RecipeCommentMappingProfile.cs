using Application.Dto_s.Comment.RecipeComment.Requests;
using Application.Dto_s.Comment.RecipeComment.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RecipeCommentMappingProfile : Profile
{
    public RecipeCommentMappingProfile()
    {
        CreateMap<RecipeCommentCreateRequest, RecipeComment>()
            .ConstructUsing(dto => new RecipeComment()
            {
                UserId = dto.UserId,
                RecipeId = dto.RecipeId,
                Text = dto.Text
            });

        CreateMap<RecipeCommentUpdateRequest, RecipeComment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));

        CreateMap<RecipeComment, RecipeCommentCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));

        CreateMap<RecipeComment, RecipeCommentUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));

        CreateMap<RecipeComment, RecipeCommentGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
    }
}