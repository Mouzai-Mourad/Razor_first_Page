namespace Razor_first_Page.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public List<Product> Products { get; set; }
	}
}
