namespace Application.Dto_s.Ingredient.Requests;

//TODO: очень много однотипных классов get all 
//TODO: придумать как добавить фильтр (маппинг через запрос фильтра)
public record IngredientGetAllPagedRequest(int PageNumber, int PageSize);