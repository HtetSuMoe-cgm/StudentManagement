using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LoginAndCRUDCoreProject.ViewsModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
