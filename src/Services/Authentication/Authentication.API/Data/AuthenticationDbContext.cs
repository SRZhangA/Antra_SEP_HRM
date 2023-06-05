using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Data;

public class AuthenticationDbContext : IdentityDbContext<User,
                                                         Role, 
                                                         Guid, 
                                                         IdentityUserClaim<Guid>,
                                                         UserRole,
                                                         IdentityUserLogin<Guid>, 
                                                         IdentityRoleClaim<Guid>, 
                                                         IdentityUserToken<Guid>>
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
