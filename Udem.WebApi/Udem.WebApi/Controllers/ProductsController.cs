using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Udem.WebApi.Data;
using Udem.WebApi.Interfaces;

namespace Udem.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        //api/products~~GET
        //api/products/id~~GET/Delete
        //api/products/~~POST/PUT

        //ok(200),notfound(404),NoContent(204),Create(201),BadRequest(400)

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values= await _productRepository.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var data= await _productRepository.GetByIdAsync(id);
            if(data==null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var addesProduct =await _productRepository.CreateAsync(product);
            return Created(string.Empty, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var chechkProduct = await _productRepository.GetByIdAsync(product.Id);
            if (chechkProduct == null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var removedEntity = await _productRepository.GetByIdAsync(id);
            if(removedEntity == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult>Upload([FromForm]IFormFile formFile)
        {
            var newName=Guid.NewGuid()+"."+Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);

        }
        [HttpGet("[action]")]
        //[FromForm]string name,[FromHeader]string auth
        public IActionResult Test([FromForm]string name,[FromHeader]string auth)
        {
            var authencation = HttpContext.Request.Headers["auth"];
            var nameR = HttpContext.Request.Form["name"];
            return Ok();
        }

    }
}
