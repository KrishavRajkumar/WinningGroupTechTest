using System.Collections.Generic;
using WinningGroup.API.Entities;
using MongoDB.Driver;
using WinningGroup.API.Models;
using System.Linq;

namespace WinningGroup.API.Services
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoCollection<Product> _products;
		public ProductRepository(IDatabaseSettings settings)
		{			
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_products = database.GetCollection<Product>(settings.CollectionName);
		}
		
		public IEnumerable<Product> GetProducts()
		{
			return _products.Find(product => true).ToList();
		}

		public IEnumerable<Product> GetProductsByParams(decimal minPrice = 0, decimal maxPrice = 0, decimal minRating = 0, decimal maxRating = 0, bool isFantastic = true)
		{
			var products = _products.Find<Product>(product => (product.Attribute.Fantastic.Value == isFantastic) 
			                                       && (minPrice != 0 && product.Price >= minPrice)
												   && (maxPrice !=0 && product.Price <= maxPrice)
												   && (minRating !=0 && product.Attribute.Rating.Value >= minRating)
												   && (maxRating != 0 && product.Attribute.Rating.Value <= maxRating)
												   ).ToList();
			return products;
		}
	}
}
