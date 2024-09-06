using Application.Dto_s;
using Application.Dto_s.Requests.Recipe;
using Application.Dto_s.Responses;
using Application.Dto_s.Responses.Ingredient;
using Application.Dto_s.Responses.Recipe;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<RecipeCreateRequest, Recipe>()
            .ConstructUsing(dto=> new Recipe(
                Guid.NewGuid(),
                dto.Title,
                dto.Link,
                null,
                dto.PreparationTime,
                dto.Servings,
                dto.Description,
                dto.TelegramUserId
                ));
        CreateMap<RecipeUpdateRequest, Recipe>()
            .ConstructUsing(dto=> new Recipe(
            Guid.NewGuid(),
            dto.Title,
            dto.Link,
            null,
            dto.PreparationTime,
            dto.Servings,
            dto.Description,
            dto.TelegramUserId
        ));
        CreateMap<Recipe, RecipeCreateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest=> dest.Servings, opt=> opt.MapFrom(src=>src.Servings))
            .ForMember(dest=> dest.Title, opt=> opt.MapFrom(src=>src.Title));
        CreateMap<Recipe, RecipeUpdateResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest=> dest.Servings, opt=> opt.MapFrom(src=>src.Servings))
            .ForMember(dest=> dest.Title, opt=> opt.MapFrom(src=>src.Title))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));
        CreateMap<Recipe, RecipeGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PreparationTime, opt => opt.MapFrom(src => src.PreparationTime))
            .ForMember(dest => dest.TelegramUserId, opt => opt.MapFrom(src => src.TelegramUserId))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Servings, opt => opt.MapFrom(src => src.Servings))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));
        
        CreateMap<Ingredient, IngredientGetResponse>()
            .ForMember(dest=> dest.Id, opt => opt.MapFrom(src=> src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.RecipeId, opt => opt.MapFrom(src => src.RecipeId))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit));
    }
}