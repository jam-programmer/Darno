using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class UserEntity : IdentityUser<Guid>
{
    public required string FullName { get; set; }
}
