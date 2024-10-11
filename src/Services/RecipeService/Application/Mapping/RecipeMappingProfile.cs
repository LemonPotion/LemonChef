using Application.Dto_s.Ingredient.Responses;
using Application.Dto_s.Recipe.Requests;
using Application.Dto_s.Recipe.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<RecipeCreateRequest, Recipe>()
            .ConstructUsing(dto => new Recipe(
                Guid.NewGuid(),
                dto.Title,
                dto.Link,
                null,
                dto.PreparationTime,
                dto.Servings,
                dto.Description,
                dto.TelegramUserId,
                dto.UserId
            ))
            .ForMember(dest => dest.Ingredients, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        CreateMap<RecipeUpdateRequest, Recipe>()
            .ConstructUsing(dto => new Recipe(
                dto.Id,
                dto.Title,
                dto.Link,
                null,
                dto.PreparationTime,
                dto.Servings,
                dto.Description,
                dto.TelegramUserId,
                dto.UserId
            ))
            .ForMember(dest => dest.Ingredients, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());
        ;

        CreateMap<Recipe, RecipeCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Servings, opt => opt.MapFrom(src => src.Servings))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<Recipe, RecipeUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Servings, opt => opt.MapFrom(src => src.Servings))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<Recipe, RecipeGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Servings, opt => opt.MapFrom(src => src.Servings))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<Ingredient, IngredientGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit));
    }
}