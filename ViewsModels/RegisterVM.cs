using System.ComponentModel.DataAnnotations;

namespace LoginAndCRUDCoreProject.ViewsModels
{
    public class RegisterVM
    {
        public IFormFile? ProfilePicture { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
