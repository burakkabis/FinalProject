﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Bir katman diger katmanin somutuyla baglanti kuramaz.ORNEK ASAGIDA.
        //IProductService productService = new ProductManager(new EfProductDal());
        //var result = productService.GetAll();
        //    return result.Data;
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //IActionResult farkli http kodlarini dondurecek yapidir.

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//Ok 200 donduruyor.
            
            }
            return BadRequest(result);
        
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)

        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
