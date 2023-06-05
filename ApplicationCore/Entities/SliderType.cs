namespace ApplicationCore.Entities;

public partial class SliderType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Slider> Sliders { get; set; } = new List<Slider>();
}
