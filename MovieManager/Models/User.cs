using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models
{
	public class User
	{
		public int UserId { get; set; }
		[Required]
		[Display(Name = "User Name")]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		
	}
}
