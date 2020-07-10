using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portal.Services
{
    public interface ISecurityProvider
    {
        string GetToken(List<Claim> claims);
        bool ValidateToken(string token);
    }
}
