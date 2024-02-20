using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Infrastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly TokenSettings _tokenSettings;

    public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
    {
        _userManager = userManager;
        _tokenSettings = options.Value;
    }
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email)            
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_tokenSettings.Secret));

        var token=new JwtSecurityToken(
            issuer:_tokenSettings.Issuer
            ,audience:_tokenSettings.Audience
            ,expires:DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMinutes)
            ,claims:claims
            ,signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
            );

        await _userManager.AddClaimAsync(user, claims);
        return token;

    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken()
    {
        throw new NotImplementedException();
    }
}
