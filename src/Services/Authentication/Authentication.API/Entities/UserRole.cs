﻿using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Entities;

public class UserRole:IdentityUserRole<Guid>
{
    //public Role Role { get; set; } = new();
    //public User User { get; set; } = new();
}
