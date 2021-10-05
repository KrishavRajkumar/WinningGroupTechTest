using AutoMapper;
using WinningGroup.API.Models;
using WinningGroup.API.Entities;

namespace TechnicalTest.API.Profiles
{
	public class ProductsProfile : Profile
	{

		public ProductsProfile()
		{
			CreateMap<Product, ProductDto>();
			CreateMap<Attribute, AttributeDto>();
			CreateMap<Fantastic, FantasticDto>();
			CreateMap<Rating, RatingDto>();
		}
	}
}
