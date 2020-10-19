using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customers");
			//.HasOne(x => x.Detail).WithOne(x => x.Customer).HasForeignKey<CustomerDetail>(x => x.Id);
		}
	}
	public class BusinessCustomerConfiguration : IEntityTypeConfiguration<BusinessCustomer>
	{
		public void Configure(EntityTypeBuilder<BusinessCustomer> builder)
		{
			builder.HasDiscriminator<string>("Discriminator").HasValue("BC");
			builder.Property("Discriminator")
				.IsFixedLength()
				.IsUnicode(false)
				.HasMaxLength(2);
		}
	}
	public class FooBarCustomerConfiguration : IEntityTypeConfiguration<FooBarCustomer>
	{
		public void Configure(EntityTypeBuilder<FooBarCustomer> builder)
		{
			builder.HasDiscriminator<string>("Discriminator").HasValue("FC");
			builder.Property("Discriminator")
				.IsFixedLength()
				.IsUnicode(false)
				.HasMaxLength(2);
		}
	}
	//public class CustomerDetailConfiguration : IEntityTypeConfiguration<CustomerDetail>
	//{
	//	public void Configure(EntityTypeBuilder<CustomerDetail> builder)
	//	{
	//		builder.ToTable("Customers");
	//	}
	//}
}
