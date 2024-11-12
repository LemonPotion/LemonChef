﻿using Application.Dto_s.Like.RecipeCommentLike.Requests;
using Application.Dto_s.Like.RecipeCommentLike.Responses;
using AutoMapper;
using Domain.Entities;
using RecipeCommentLikeUpdateRequest = Application.Dto_s.Like.RecipeCommentLike.Requests.RecipeCommentLikeUpdateRequest;

namespace Application.Mapping;

public class RecipeCommentLikeMappingProfile : Profile
{
    public RecipeCommentLikeMappingProfile()
    {
        CreateMap<RecipeCommentLikeCreateRequest, RecipeCommentLike>()
            .ConstructUsing(dto => new RecipeCommentLike()
            {
                UserId = dto.UserId,
                RecipeCommentId = dto.RecipeCommentId
            });

        CreateMap<RecipeCommentLikeUpdateRequest, RecipeCommentLike>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeCommentId, opt => opt.MapFrom(src => src.RecipeCommentId));

        CreateMap<RecipeCommentLike, RecipeCommentLikeCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeCommentId, opt => opt.MapFrom(src => src.RecipeCommentId));


        CreateMap<RecipeCommentLike, RecipeCommentLikeUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeCommentId, opt => opt.MapFrom(src => src.RecipeCommentId));


        CreateMap<RecipeCommentLike, RecipeCommentLikeGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.RecipeCommentId, opt => opt.MapFrom(src => src.RecipeCommentId));
    }
}