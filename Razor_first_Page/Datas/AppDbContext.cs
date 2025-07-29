using Microsoft.EntityFrameworkCore;
using Razor_first_Page.Models;

namespace Razor_first_Page.Datas
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Models.Product> Products { get; set; }
		public DbSet<Models.Category> Categories { get; set; }
		public DbSet<Models.Order> Orders { get; set; }
		//public DbSet<Models.OrderProduct> OrderProducts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category[]
				{
					new Category { Id = 1, Nom = "Electronique" },
					new Category { Id = 2, Nom = "Mode" },
					new Category { Id = 3, Nom = "Autres" }
				});

			modelBuilder.Entity<Product>().HasData(
				new Product[]
				{
					new Product { Id = 1, Nom = "Ordinateur", Prix = 1000, CategorieId = 1 },
					new Product { Id = 2, Nom = "Television", Prix = 500, CategorieId = 1 },
					new Product { Id = 3, Nom = "Chaussures", Prix = 100, CategorieId = 2 },
					new Product { Id = 4, Nom = "T-shirt", Prix = 20, CategorieId = 2 }
				});

			//	modelBuilder.Entity<Models.Product>()
			//		.Property(p => p.Prix)
			//		.HasColumnType("decimal(18,2)");

			//	modelBuilder.Entity<Models.Product>()
			//		.HasOne(p => p.Categorie)
			//		.WithMany()
			//		.HasForeignKey(p => p.CategorieId);

			//	modelBuilder.Entity<Models.OrderProduct>()
			//		.HasKey(op => new { op.OrderId, op.ProductId });

			//	modelBuilder.Entity<Models.OrderProduct>()
			//		.HasOne(op => op.Order)
			//		.WithMany()
			//		.HasForeignKey(op => op.OrderId)
			//		.OnDelete(DeleteBehavior.Restrict);

			//	modelBuilder.Entity<Models.OrderProduct>()
			//		.HasOne(op => op.Product)
			//		.WithMany()
			//		.HasForeignKey(op => op.ProductId)
			//		.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
