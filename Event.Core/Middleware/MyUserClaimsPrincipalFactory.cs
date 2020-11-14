using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Event.Core.Entities;

namespace Event.Core.Middleware
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public MyUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Lastname", user.Lastname));
            identity.AddClaim(new Claim("Firstname", user.Firstname));
            return identity;
        }
    }
}
