using System.Collections.Generic;
using System.Security.Claims;

namespace Portal.Services.V1U0
{
    public interface ISecurityProvider
    {
        string GetToken(List<Claim> claims);
        bool ValidateToken(string token);
    }
}
