﻿using System.Security.Claims;

namespace Api.Application.Interfaces.Tokens;
public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken();
}
