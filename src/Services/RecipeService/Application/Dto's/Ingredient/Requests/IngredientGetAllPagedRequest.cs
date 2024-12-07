namespace Application.Dto_s.Ingredient.Requests;

//TODO: очень много однотипных классов get all 
//TODO: придумать как добавить фильтр (ОДата)
public record IngredientGetAllPagedRequest(
    int PageNumber, 
    int PageSize);