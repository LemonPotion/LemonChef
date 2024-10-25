using Domain.Entities;

namespace Domain.Interfaces;

public interface ICommentable
{
    public long CommentCount { get; }
}