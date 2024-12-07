namespace Application.Dto_s.Comment.RecipeComment.Requests;

public record RecipeCommentGetAllPagedRequest(
    int PageNumber, 
    int PageSize);