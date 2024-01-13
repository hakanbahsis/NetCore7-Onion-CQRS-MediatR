namespace Api.Persistance.Configurations;
public class BrandConfigurations : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

        Faker faker = new Faker("tr");

        //builder.HasData(
        //    new Brand
        //    {
        //        Id = 1,
        //        Name = faker.Commerce.Department()
        //    });

        for (int i = 1; i < 4; i++)
        {
            builder.HasData(
                new Brand
                {
                    Id = i,
                    Name = faker.Commerce.Department()
                });
        }
    }
}

