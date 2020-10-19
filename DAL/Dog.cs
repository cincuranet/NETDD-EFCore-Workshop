using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
	public class Dog
	{
		string _url;

		public int DogNumber { get; set; }
		public string Name { get; set; }
		public virtual Owner Owner { get; set; }
		public int OwnerId { get; set; }
		public string Url
		{
			get => _url;
		}
		public bool Active { get; set; }

		public Dog()
		{ }

		public Dog(string url, IEntityType entityType)
		{
			_url = url;
		}

		public void SetUrl(string url)
		{
			_url = url;
		}
	}
}
