using System.Collections.Generic;

namespace Fcg.Infrastructure.Identity;

public interface IJwtService
{
    string GenerateToken(
        ApplicationUser user,
        IList<string> roles);
}