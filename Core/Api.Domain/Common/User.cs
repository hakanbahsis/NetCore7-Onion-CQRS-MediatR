namespace Api.Domain.Common;
public class User:IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
}
