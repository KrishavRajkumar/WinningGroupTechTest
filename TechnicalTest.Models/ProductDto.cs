using System;

namespace WinningGroup.API.Models
{
	public class ProductDto
	{
		public string Id { get; set; }

		public string Sku { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public AttributeDto Attribute { get; set; }
	}
}
