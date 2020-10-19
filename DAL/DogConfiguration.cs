using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
	public class DogConfiguration : IEntityTypeConfiguration<Dog>
	{
		public void Configure(EntityTypeBuilder<Dog> builder)
		{
			builder.HasKey(x => x.DogNumber);
			builder.HasAlternateKey(x => x.Name);
			builder.Property(x => x.Name)
				.HasMaxLength(30)
				.IsRequired()
				.HasColumnName("DogName");
			builder.HasOne(x => x.Owner)
				.WithMany(x => x.Dogs)
				.HasForeignKey(x => x.OwnerId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Property(x => x.Url)
				.HasField("_url")
				.UsePropertyAccessMode(PropertyAccessMode.Property);
			builder.Property<DateTimeOffset>("Created");
			builder.HasQueryFilter(x => x.Active == true && x.Active == true);
			builder.ToTable("Dogs");
			//builder.HasData(new[]
			//{
			//	new Dog()
			//	{
			//		DogNumber = -1,
			//		Name = "Bingo",
			//		Active = true,
			//		Owner = new Owner()
			//		{
			//			FirstName = "Jiri",
			//			LastName = "Cincura",
			//		},
			//	}
			//});
		}
	}
}
