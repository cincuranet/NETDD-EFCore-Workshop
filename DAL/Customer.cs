using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//public CustomerDetail Detail { get; set; }
	}
	public class BusinessCustomer : Customer
	{
		public string BusinessName { get; set; }
		public string BusinessAddress { get; set; }
	}
	public class FooBarCustomer : Customer
	{
		public string FooBarName { get; set; }
		public string FooBarAddress { get; set; }
	}

	//public class CustomerDetail
	//{
	//	public int Id { get; set; }
	//	public Customer Customer { get; set; }
	//	public string BusinessName { get; set; }
	//	public string BusinessAddress { get; set; }
	//}
}
