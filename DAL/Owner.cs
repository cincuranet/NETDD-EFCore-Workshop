using System;
using System.Collections.Generic;

namespace DAL
{
	public class Owner
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public virtual ICollection<Dog> Dogs { get; set; }
		//public Address InvoiceAddress { get; set; }
		//public Address ShippingAddress { get; set; }
		public Result Result { get; set; }
		public byte[] Stamp { get; set; }
		public string Note { get; set; }
	}

	public class Result
	{
		public TimeSpan Time1 { get; set; }
		public TimeSpan Time2 { get; set; }
	}

	public class Address
	{
		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public string City { get; set; }
		public string Postcode { get; set; }
		public string Country { get; set; }
	}
}
