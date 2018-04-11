﻿using Microsoft.AspNetCore.Mvc;
using ninja_shop.api.Services;

namespace ninja_shop.api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            if (!_productRepository.Exists(id))
            {
                return NotFound();
            }

            var product = _productRepository.GetProduct(id);

            return Ok(product);
        }
    }
}