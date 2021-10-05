using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WinningGroup.API.Services;
using AutoMapper;
using WinningGroup.API.Models;
using Microsoft.Extensions.Logging;

namespace WinningGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IMapper mapper
                                  ,IProductRepository productRepository
                                  ,ILogger<ProductsController> logger)
        {
            _mapper = mapper ??
                         throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ??
                        throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ??
                        throw new ArgumentNullException(nameof(logger));

        }
            
        public IActionResult GetProducts()
        {           
            var products = _productRepository.GetProducts();
            var productResult = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productResult);
        }

        [HttpGet(Name = "GetProductsByParams")]
        public IActionResult GetProductsByParams([FromQuery]decimal minPrice = 0, 
                                                 [FromQuery]decimal maxPrice = 0, 
                                                 [FromQuery]decimal minRating = 0, 
                                                 [FromQuery]decimal maxRating = 0,
                                                 [FromQuery]bool isFantastic = true)
        {
            var products = _productRepository.GetProductsByParams(minPrice, maxPrice, minRating, maxRating, isFantastic);
            var productResult = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productResult);
        }
    }
}