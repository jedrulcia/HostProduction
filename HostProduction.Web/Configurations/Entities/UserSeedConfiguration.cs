using HostProduction.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostProduction.Configurations.Entities
{
	public class UserSeedConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			var hasher = new PasswordHasher<User>();
			builder.HasData(
				new User
				{
					Id = "654bced5-375b-5291-0a59-1dc59923d1b0",
					UserName = "admin@localhost.com",
					NormalizedUserName = "ADMIN@LOCALHOST.COM",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					PasswordHash = hasher.HashPassword(null, "Admin!2"),
					EmailConfirmed = true
				});
		}
	}
}
