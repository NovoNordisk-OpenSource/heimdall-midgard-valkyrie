namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Configurations;

/// <summary>
///     Represents the entity type configuration for the <see cref="ScaffoldTask" /> class.
/// </summary>
public class ScaffoldTaskTypeConfiguration : IEntityTypeConfiguration<ScaffoldTask>
{
    private readonly IEnumerable<ScaffoldTask>? _seed;

    public ScaffoldTaskTypeConfiguration()
    {
    }

    public ScaffoldTaskTypeConfiguration(IEnumerable<ScaffoldTask> seed)
    {
        _seed = seed;
    }

    /// <summary>
    ///     Configures the entity type.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public void Configure(EntityTypeBuilder<ScaffoldTask> builder)
    {
        builder.ToTable("ScaffoldTask");
        builder.HasKey(v => v.Id);
        builder.Ignore(v => v.DomainEvents);
        builder.Property(v => v.Id).IsRequired();
        builder.Property(v => v.Created).IsRequired();

        builder.HasOne(o => o.Account)
               .WithMany()
               .HasForeignKey("AccountId");

        builder.OwnsMany(
            p => p.Options, a =>
            {
                a.WithOwner().HasForeignKey("OwnerId");
                a.Property<Guid>("Id");
                a.HasKey("Id");
            });
        
        if (_seed != null)
        {
            builder.HasData(_seed);
        }
    }
}