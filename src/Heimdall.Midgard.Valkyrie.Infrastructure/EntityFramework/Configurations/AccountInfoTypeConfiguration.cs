namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Configurations;

/// <summary>
///     Represents the entity type configuration for the <see cref="AccountInfo" /> class.
/// </summary>
public class AccountInfoTypeConfiguration : IEntityTypeConfiguration<AccountInfo>
{
    private readonly IEnumerable<AccountInfo>? _seed;

    public AccountInfoTypeConfiguration()
    {
    }

    public AccountInfoTypeConfiguration(IEnumerable<AccountInfo> seed)
    {
        _seed = seed;
    }

    /// <summary>
    ///     Configures the entity type.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    public void Configure(EntityTypeBuilder<AccountInfo> builder)
    {
        builder.ToTable("AccountInfo");
        builder.HasKey(v => v.Identifier);
        builder.Property(v => v.Identifier).ValueGeneratedNever();
        
        if (_seed != null)
        {
            builder.HasData(_seed);
        }
    }
}