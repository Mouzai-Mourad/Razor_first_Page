namespace Razor_first_Page.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Nom { get; set; }

		public List<Product> Produits { get; set; }
	}
}
