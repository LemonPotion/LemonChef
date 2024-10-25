using Domain.Entities.Base;
using Domain.Interfaces;

namespace Domain.Entities;

public class CommentFile : LemonChefFile
{
    public Guid CommentId { get; set; }

    public Comment Comment { get; set; }
}