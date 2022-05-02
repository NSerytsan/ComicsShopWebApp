using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
    public class EditProfileViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string FullName { get; set; } = null!;
        
        [Display(Name = "Адреса")]
        public string DefaultDeliveryAddress { get; set; } = null!;
    }
}