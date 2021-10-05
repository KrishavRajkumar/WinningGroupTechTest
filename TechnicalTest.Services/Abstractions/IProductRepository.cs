using System.Collections.Generic;
using System.Threading.Tasks;
using WinningGroup.API.Entities;

namespace WinningGroup.API.Services
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();

		IEnumerable<Product> GetProductsByParams(decimal minPrice = 0, decimal maxPrice = 0, decimal minRating = 0, decimal maxRating = 0, bool isFantastic = true);
	}
}
