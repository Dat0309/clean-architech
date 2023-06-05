namespace ApplicationCore.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string FullDescription { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? Type { get; set; }

    public DateTime CreatedTime { get; set; }

    public string Author { get; set; } = null!;

    public virtual PostType? TypeNavigation { get; set; }
}
