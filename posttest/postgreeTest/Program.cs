

using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Posthreetest
{
	class Program
	{
		public static void Main(string[] Args)
		{


			UserRegistration userRegistration = new UserRegistration();


			userRegistration.MainMenu();
		}
	}

	interface IRegistr
	{
		void MainMenu();
		void Register();
		void Login();

	}

	class UserRegistration : IRegistr
	{
		ApplicationContext context = new ApplicationContext();
		User user = new User();
		string? slashCom = "";
		public void MainMenu()
		{
			Console.WriteLine("MainMenu/");

			Console.WriteLine("/r For register\n/l For login");
			slashCom = Console.ReadLine();


			switch (slashCom)
			{
				case "/r":
					Register();
					break;
				case "/l":
					Login();
					break;
			}
		}
		public void Login()
		{
			Console.WriteLine("MainMenu/Login");

			Console.Write("Enter login:");
			user.name = Console.ReadLine();
			Console.Write("\nEnter password:");
			user.password = Console.ReadLine();
			
			// check login in database
		}
		public void Register()
		{

			Console.WriteLine("MainMenu/Register");

			Console.Write("Enter login:");
			user.name = Console.ReadLine();
			Console.Write("\nEnter your passowrd:");
			user.password = Console.ReadLine();
			Console.WriteLine($"Register account? Username:{user.name}\nPassword:{user.password}\n/y For yes\n/n For exit to MainMenu");
			slashCom = Console.ReadLine();
			switch (slashCom)
			{
				case "/y":
					user.permissionlevel = 0;
					Console.WriteLine("Saving...");

					context.users.Add(user);
					context.SaveChanges();

					Console.WriteLine("Save sucsesful!");
					MainMenu();
					break;
				case "/n":
					MainMenu();
					break;
			}
		}
	}


	public class User
	{
		public int id { get; set; }
		public string? name { get; set; }
		public string? password { get; set; }
		public int permissionlevel { get; set; }
	}


	public class ApplicationContext : DbContext
	{
		public DbSet<User> users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			dbContextOptionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Ff123533");
		}
		public ApplicationContext()
		{
			Database.EnsureCreated();
		}


	}
}