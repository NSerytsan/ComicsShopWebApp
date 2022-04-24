using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
    public class UserSupportViewModel
    {
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Текст звернення")]
        public string TextMessage { get; set; } = null!;
    }
}
