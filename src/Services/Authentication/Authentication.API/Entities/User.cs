using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Entities;

public class User:IdentityUser<Guid>
{

    public ICollection<UserRole>? RolesForUser { get; set; }
}
