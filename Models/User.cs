using Microsoft.AspNetCore.Identity;

namespace LoginAndCRUDCoreProject.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
