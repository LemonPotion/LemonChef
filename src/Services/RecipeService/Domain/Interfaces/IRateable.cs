namespace Domain.Interfaces;

public interface IRateable
{
    public long ViewCount { get; set; }

    public long LikeCount { get; set; }

    public long CommentCount { get; set; }

    public long ShareCount { get; set; }
}