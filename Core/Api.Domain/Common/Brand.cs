using Api.Domain.Common.Base;

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
    public required string Name { get; set; }
}

