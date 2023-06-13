using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Entities;

public class User:IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    //public ICollection<UserRole>? RolesForUser { get; set; }
}
