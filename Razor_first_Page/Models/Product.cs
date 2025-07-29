namespace Razor_first_Page.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		public decimal Prix { get; set; }
		public string? Description { get; set; }

		public List<Order> Orders { get; set; }

		public int CategorieId { get; set; }
		public Category Categorie { get; set; }
	}
}
