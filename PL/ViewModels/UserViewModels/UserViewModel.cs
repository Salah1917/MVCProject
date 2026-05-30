using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Roles")]
        public List<string> Roles { get; set; } = new();
    }
}
