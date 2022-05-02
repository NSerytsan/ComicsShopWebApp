using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Назва ролі")]
        public string RoleName {get; set;} = string.Empty;
    }
}