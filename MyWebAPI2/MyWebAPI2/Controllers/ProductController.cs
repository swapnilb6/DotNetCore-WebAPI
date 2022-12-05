using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository = null;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpPost]
        [Route("Products")]
        public IActionResult AddProduct([FromBody]ProductModel product)
        {
            _productRepository.AddProduct(product);

            var productList = _productRepository.GetProducts();

            return Ok(productList);
        }
    }
}
