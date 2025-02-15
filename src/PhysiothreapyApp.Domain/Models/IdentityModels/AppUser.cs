using Microsoft.AspNetCore.Identity;

namespace PhysiothreapyApp.Domain.Models.IdentityModels;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
