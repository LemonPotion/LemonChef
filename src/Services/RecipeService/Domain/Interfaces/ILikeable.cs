using Domain.Entities;

namespace Domain.Interfaces;

//TODO: подумать где реализовать методы круд для лайков и т.д
public interface ILikeable
{
    public long LikeCount { get; }
}