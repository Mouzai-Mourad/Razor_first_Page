﻿namespace Razor_first_Page.Models
{
	public class OrderProduct
	{
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public DateTime OrderDate { get; set; }
		public Order Order { get; set; }
		public Product Product { get; set; }
	}
}
