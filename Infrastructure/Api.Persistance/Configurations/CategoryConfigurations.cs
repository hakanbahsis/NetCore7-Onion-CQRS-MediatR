namespace Api.Persistance.Configurations;
public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Category category1 = new() 
        {
            Id=1,
            Name = "Elektrik",
            Priority = 1,
            ParentId=0
        };
        Category parent1 = new()
        {
            Id = 3,
            Name = "Bilgisayar",
            Priority = 1,
            ParentId = 1
        };

        Category category2 = new() 
        {
            Id=2,
            Name = "Moda",
            Priority = 1,
            ParentId=0
        };

        Category parent2 = new() 
        {
            Id=4,
            Name = "Kadın",
            Priority = 1,
            ParentId=2
        };
        
        builder.HasData(category1,category2,parent1,parent2);
    }
}

