namespace ApplicationCore.Entities;

public partial class Slider
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Subtitle { get; set; }

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public string? Url { get; set; }

    public int? Ordering { get; set; }

    public int? Type { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual SliderType? TypeNavigation { get; set; }
}
