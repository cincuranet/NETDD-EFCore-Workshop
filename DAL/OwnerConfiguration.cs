using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace DAL
{
	public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder.Property(x => x.Id)
				.UseIdentityColumn(); 
			builder.Property<DateTimeOffset>("Created");
			//builder.OwnsOne(x => x.InvoiceAddress);
			//builder.OwnsOne(x => x.ShippingAddress);
			builder.ToTable("Owners");
			builder.Property(x => x.Result)
				.HasConversion(new ResultValueConverter());
			builder.Property(x => x.Stamp)
				//.IsConcurrencyToken()
				//.ValueGeneratedOnAddOrUpdate()
				//.HasColumnType("rowversion")
				.IsRowVersion();
		}
	}

	class ResultValueConverter : ValueConverter<Result, string>
	{
		public ResultValueConverter()
			: base(x => Make(x), x => Unmake(x), null)
		{ }

		static string Make(Result result) => JsonConvert.SerializeObject(result);
		static Result Unmake(string s) => JsonConvert.DeserializeObject<Result>(s);
	}
}
