﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{


    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string? ProfilePicture { get; set; } = "DefaultProfilePicture.jpg";


    public string? Bio { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }

    public bool IsExternalAccount { get; set; } = false;


    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

    
}
