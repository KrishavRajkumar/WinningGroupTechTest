using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinningGroup.API.Entities
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Sku { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public Attribute Attribute { get; set; }
	}
}
