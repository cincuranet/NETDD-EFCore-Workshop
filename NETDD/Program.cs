using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETDD
{ 
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new MyContext())
			{
				//db.Database.EnsureDeleted();
				//db.Database.EnsureCreated();

				var script = db.GetService<IMigrator>().GenerateScript(idempotent: true);
				Console.WriteLine(script);

				//db.Set<Customer>().Load();
				//db.Set<Customer>().OfType<BusinessCustomer>().Load();
				//db.Set<Customer>().Where(x => !(x is BusinessCustomer)).Load();

				//db.Set<Customer>().Add(new BusinessCustomer() { Name = "", BusinessAddress = "", BusinessName = "" });
				//db.SaveChanges();

				//var owner = new Owner() { FirstName = "", LastName = "", Result = new Result() { Time1 = TimeSpan.Zero, Time2 = TimeSpan.FromMinutes(2) } };
				//db.Add(owner);
				//using (var tx = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
				//{
				//	var owner = db.Owners.Find(1);
				//	owner.FirstName = "Jiri";
				//	db.SaveChanges(false);
				//	tx.Commit();
				//	db.ChangeTracker.AcceptAllChanges();
				//}
				//db.Database.OpenConnection();
				//var conn = (SqlConnection)db.Database.GetDbConnection();
				//using (var tx = conn.BeginTransaction(System.Data.IsolationLevel.Serializable, "KamilKielbasa"))
				//{
				//	db.Database.UseTransaction(tx);
				//	{
				//		var owner = db.Owners.Find(1);
				//		owner.FirstName = "Jiri";
				//		Console.ReadLine();
				//		db.SaveChanges(false);
				//		tx.Commit();
				//		db.ChangeTracker.AcceptAllChanges();
				//	}
				//	db.Database.UseTransaction(null);
				//}

				//while (true)
				//{
				//	try
				//	{
				//		db.SaveChanges();
				//		break;
				//	}
				//	catch (DbUpdateConcurrencyException ex)
				//	{
				//		foreach (var entry in ex.Entries)
				//		{
				//			Console.WriteLine(entry);
				//			entry.OriginalValues.SetValues(entry.GetDatabaseValues());
				//			//entry.Reload();
				//		}
				//		continue;
				//	}
				//}

				//owner.FirstName = "Jiri";
				//db.SaveChanges();

				//db.Remove(new Owner() { Id = 1 });
				////var entry = db.ChangeTracker.Entries().Where(x => (x.Entity as Owner)?.Id == 1).FirstOrDefault();
				////entry.State = EntityState.Deleted;
				//db.SaveChanges();

				//db.KeylessEntities
				//	.FromSqlInterpolated($"select d.DogName as DogName, o.LastName as OwnerLastName from Dogs d inner join Owners o on (d.OwnerId = o.Id)")
				//	.Where(x => x.DogName != string.Empty)
				//	.Load();

				//db.Owners.TagWith("interesting query").Where(x => x.ShippingAddress.City == "Warsaw").Load();

				//db.Dogs.Where(x => MyContext.MatchesDogsName(x.Name, "bingo")).ToList();
				//var id = 10;
				//db.Dogs.FromSqlInterpolated($"select * from Dogs where DogNumber = {id}").ToList();

				//var dogs = db.Dogs.ToList();
				//var query = EF.CompileQuery<MyContext, Owner>(context => context.Owners.Where(x => x.Id == 1));
				//var owners = query(db).ToList();
				////db.Owners/*.Where(x => x.Id == 1)*/.Load();
				//foreach (var item in dogs)
				//{
				//	//db.Entry(item).Reference(x => x.Owner).Load();
				//	Console.WriteLine($"Name: {item.Name} - Owner: {item.Owner.LastName}");
				//}
				//db.Dogs.AsNoTracking().Where(x => true).ToList();
				//var entries = db.ChangeTracker.Entries().ToList();
			}
		}
	}
}

/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION MatchesDogsName 
(
	@Name nvarchar(30),
	@Match nvarchar(30)
)
RETURNS bit
AS
BEGIN
	IF (UPPER(@Name) = UPPER(@Match))
	BEGIN
		RETURN 1;
	END
	RETURN 0;
END
GO


 */

// https://docs.microsoft.com/en-us/ef/core/providers/sql-server/functions
