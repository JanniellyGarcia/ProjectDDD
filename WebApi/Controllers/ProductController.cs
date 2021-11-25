using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Intefaces;
using Service.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBaseService<Product> _baseProductService;
        private IProductService _productService;
        private readonly ILogger<UserController> _logger;


        public ProductController(IBaseService<Product> baseProductService
            , ILogger<UserController> logger, IProductService productService)
        {
            _baseProductService = baseProductService;
            _productService = productService;
            _logger = logger;

        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _baseProductService.Add<ProductValidator>(product).Id);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _baseProductService.Update<ProductValidator>(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProductService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _productService.GetProducts());        
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProductService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
