using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _datacontext;

        public ProductsController(StoreContext datacontext)
        {
            _datacontext = datacontext ;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _datacontext.Products.ToListAsync());
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _datacontext.Products.FindAsync(id));
        }
    }
}