using System;
namespace HelloWorld.ConsoleApp.Models
{
	public class User
	{
		public long Id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public DateTime birthdate { get; set; }
	}
}
