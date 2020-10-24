using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
	public class Seed
	{
		public static async Task SeedUsers(DataContext context)
		{
			if (await context.Users.AnyAsync()) return;

			var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
			var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

			foreach (var user in users)
			{
				using var hmac = new HMACSHA512();
				user.UserName = user.UserName.ToLower();
				user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
				user.PasswordSalt = hmac.Key;

				context.Users.Add(user); //this no need to use await in front, because this havent talk to Database
			}

			await context.SaveChangesAsync(); //this need to use await because it does update and talk to Database.
		}
	}
}
