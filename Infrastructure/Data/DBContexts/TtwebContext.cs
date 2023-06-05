using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entities;

public partial class TtwebContext : DbContext
{
    public TtwebContext()
    {
    }

    public TtwebContext(DbContextOptions<TtwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    public virtual DbSet<SliderType> SliderTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC07267E1543");

            entity.ToTable("Contact");

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Subject).HasMaxLength(150);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC0793233B2A");

            entity.ToTable("Post");

            entity.Property(e => e.Author).HasMaxLength(30);
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ShortDescription).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK__Post__Type__403A8C7D");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostType__3214EC0756B2E914");

            entity.ToTable("PostType");

            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Slider__3214EC075F98817E");

            entity.ToTable("Slider");

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Ordering).HasDefaultValueSql("((0))");
            entity.Property(e => e.Subtitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Sliders)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK__Slider__Type__3A81B327");
        });

        modelBuilder.Entity<SliderType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SliderTy__3214EC07D6DE75B0");

            entity.ToTable("SliderType");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
