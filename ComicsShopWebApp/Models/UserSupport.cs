using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
	[Table("UserSupport")]
	public class UserSupport
	{
		public int Id { get; set; }
		public string UserId { get; set; } = null!;

		[Required(ErrorMessage = "Поле не повинно бути порожнім")]
		[Display(Name = "Текст звернення")]
		public string? TextMessage { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; } = DateTime.Now;

		public virtual User User { get; set; } = null!;
	}
}
