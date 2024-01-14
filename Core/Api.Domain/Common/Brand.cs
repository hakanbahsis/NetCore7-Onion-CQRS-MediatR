namespace Api.Domain.Common;
public class Brand : EntityBase
{
    public Brand()
    {
        
    }
    public Brand(string name)
    {
        Name=name;
    }
    public  string Name { get; set; }
}

