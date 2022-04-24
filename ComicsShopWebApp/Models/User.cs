using Microsoft.AspNetCore.Identity;

namespace ComicsShopWebApp.Models
{
	public class User : IdentityUser
	{
		public User()
		{
			UserSupports = new HashSet<UserSupport>();
			Orders = new HashSet<Order>();
		}

		public string FullName { get; set; } = null!;
		public string? DefaultDeliveryAddress { get; set; }

		public virtual ICollection<UserSupport> UserSupports { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
	}
}
