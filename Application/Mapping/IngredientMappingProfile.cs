using Application.Dto_s.Requests;
using Application.Dto_s.Requests.Ingredient;
using Application.Dto_s.Responses;
using Application.Dto_s.Responses.Ingredient;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class IngredientMappingProfile : Profile
{
    public IngredientMappingProfile()
    {
        CreateMap<IngredientCreateRequest, Ingredient>()
            .ConstructUsing(dto => new Ingredient(
                Guid.NewGuid(), 
                dto.Name,
                dto.Quantity,
                dto.Unit,
                dto.RecipeId
            ));
        CreateMap<IngredientUpdateRequest, Ingredient>()
            .ConstructUsing(dto => new Ingredient(
                dto.Id, 
                dto.Name,
                dto.Quantity,
                dto.Unit,
                dto.RecipeId
            ));
        CreateMap<IngredientCreateResponse, Ingredient>()
            .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src=>src.Id))
            .ForMember(dest=> dest.Quantity, opt=> opt.MapFrom(src=>src.Quantity))
            .ForMember(dest=> dest.RecipeId, opt=> opt.MapFrom(src=>src.RecipeId))
            .ForMember(dest=> dest.Name, opt=> opt.MapFrom(src=>src.Name))
            .ForMember(dest=> dest.Unit, opt=> opt.MapFrom(src=>src.Unit));
        CreateMap<Ingredient, IngredientCreateResponse>()
            .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src=>src.Id))
            .ForMember(dest=> dest.Quantity, opt=> opt.MapFrom(src=>src.Quantity))
            .ForMember(dest=> dest.RecipeId, opt=> opt.MapFrom(src=>src.RecipeId))
            .ForMember(dest=> dest.Name, opt=> opt.MapFrom(src=>src.Name))
            .ForMember(dest=> dest.Unit, opt=> opt.MapFrom(src=>src.Unit));
        CreateMap<Ingredient, IngredientUpdateResponse>()
            .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src=>src.Id))
            .ForMember(dest=> dest.Quantity, opt=> opt.MapFrom(src=>src.Quantity))
            .ForMember(dest=> dest.RecipeId, opt=> opt.MapFrom(src=>src.RecipeId))
            .ForMember(dest=> dest.Name, opt=> opt.MapFrom(src=>src.Name))
            .ForMember(dest=> dest.Unit, opt=> opt.MapFrom(src=>src.Unit));
        CreateMap<Ingredient, IngredientGetResponse>()
            .ForMember(dest=> dest.Id, opt=> opt.MapFrom(src=>src.Id))
            .ForMember(dest=> dest.Quantity, opt=> opt.MapFrom(src=>src.Quantity))
            .ForMember(dest=> dest.RecipeId, opt=> opt.MapFrom(src=>src.RecipeId))
            .ForMember(dest=> dest.Name, opt=> opt.MapFrom(src=>src.Name))
            .ForMember(dest=> dest.Unit, opt=> opt.MapFrom(src=>src.Unit));
    }
}