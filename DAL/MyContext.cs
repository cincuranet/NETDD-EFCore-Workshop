using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
	public class MyContext : DbContext
	{
		public DbSet<Dog> Dogs => Set<Dog>();
		public DbSet<Owner> Owners => Set<Owner>();
		public DbSet<KeylessEntity> KeylessEntities => Set<KeylessEntity>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				foreach (var prop in entity.GetProperties())
				{
					if (prop.ClrType == typeof(string))
					{
						if (prop.GetMaxLength() == null)
						{
							prop.SetMaxLength(100);
						}
						prop.IsNullable = false;
					}
				}
			}

			modelBuilder.Entity<KeylessEntity>()
				.HasNoKey();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(Settings.ConnectionString, options =>
			{
				options.MaxBatchSize(42);
			});
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.UseLoggerFactory(MyLoggerFactory);
			//optionsBuilder.UseLazyLoadingProxies();
		}

		public override int SaveChanges()
		{
			foreach (var item in ChangeTracker.Entries())
			{
				if (item.State == EntityState.Added)
				{
					item.CurrentValues["Created"] = DateTimeOffset.Now;
				}
			}
			return base.SaveChanges();
		}

		[DbFunction]
		public static bool MatchesDogsName(string name, string match)
		{
			throw new InvalidOperationException();
		}

		static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
	}
}
