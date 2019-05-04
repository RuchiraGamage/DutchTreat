using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]  //tell this is a api controller which which serves to http responses
    [Produces("application/json")] //indicate this returns json type responses
    public class ProductsController :ControllerBase
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDutchRepository repository,ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /*
         
        there are few ways we can return from the api end point
        1.IEnumarable<Products> -->this is kind of tide iin to it can be made some errors
        2.async Task<ActionResult<Product>>
        3.jasonResult --->specific type when return wrap data with 'json(data)'
        //but with EF6 there is content negotiation when request come serve for the request as per the request
        //it can handle using IActionResult
        4.IActionResult  -->this doesn't specify the type 
        5.ActionResult<IEnumarable<Products>>

         */

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()//this descriptive API is usful for, public API's like Swagger
            //for the normal cases like building our own webApplication can simply use "IActionResult" to return
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products : {ex}");
                return BadRequest("Failed to get products");
            }
        } 
    }
}
