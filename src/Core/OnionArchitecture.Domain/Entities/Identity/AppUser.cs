using Microsoft.AspNetCore.Identity;

namespace OnionArchitecture.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenEndDate { get; set; }


    }
}
