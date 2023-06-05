namespace ApplicationCore.Entities;

public partial class PostType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
