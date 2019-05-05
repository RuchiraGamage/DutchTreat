using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IDutchRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderid)
        {

            try
            {
                var order = _repository.GetOrderById(orderid);

                if (order != null)
                    return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
                return NotFound("Order doesn't exist");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get specific items for the order :{ex}");
                return BadRequest("Unable to get specific items for the order");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int orderid, int id)
        {
            try
            {
                var order = _repository.GetOrderById(orderid);

                if (order != null)
                {
                    var item = order.Items.Where(i=>i.Id==id).FirstOrDefault();
                    if (item != null)
                        return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
                    return NotFound("Item not found");
                }
                else
                {
                    return NotFound("Order not found");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get specific items for the order :{ex}");
                return BadRequest("Unable to get specific items for the order");
            }
        }
    }
}
