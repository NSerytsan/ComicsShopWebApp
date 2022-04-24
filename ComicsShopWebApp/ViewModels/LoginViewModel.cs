using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "E-mail")]
		public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; } = null!;

		[Display(Name = "Запам'ятати мене")]
		public bool RememberMe { get; set; }
	}
}
