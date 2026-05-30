using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.UserViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public List<RoleCheckbox> Roles { get; set; } = new();
    }

    public class RoleCheckbox
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
