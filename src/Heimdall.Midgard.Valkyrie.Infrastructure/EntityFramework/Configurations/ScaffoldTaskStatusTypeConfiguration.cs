namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Configurations;

/// <summary>
///     Represents the entity type configuration for the <see cref="ScaffoldTaskStatus" /> class.
/// </summary>
public class ScaffoldTaskStatusTypeConfiguration : IEntityTypeConfiguration<ScaffoldTaskStatus>
{
    private readonly IEnumerable<ScaffoldTaskStatus>? _seed;

    public ScaffoldTaskStatusTypeConfiguration()
    {
    }

    public ScaffoldTaskStatusTypeConfiguration(IEnumerable<ScaffoldTaskStatus> seed)
    {
        _seed = seed;
    }

    /// <summary>
    ///     Configures the entity type.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public void Configure(EntityTypeBuilder<ScaffoldTaskStatus> builder)
    {
        builder.ToTable("BuildStatus");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(o => o.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        if (_seed != null)
        {
            builder.HasData(_seed);
        }
    }
}