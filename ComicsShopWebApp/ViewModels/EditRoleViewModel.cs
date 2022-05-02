using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; } = null!;

        [Required]
        [Display(Name = "Назва ролі")]
        public string RoleName { get; set; } = null!;

        public List<string> Users { get; set; }
    }
}
