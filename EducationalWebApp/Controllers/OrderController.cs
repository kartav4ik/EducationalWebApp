using AppDomain.Models;
using AppDomain.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllOrderDTO>> GetOrders()
        {
            var response = await _orderService.GetOrders();
            var data = response.Data.Select(p => GetAllOrderDTO.New(p));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneOrderDTO>> GetOrder(Guid id)
        {
            var response = await _orderService.GetOrder(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            var data = GetOneOrderDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<NewOrderDTO>> AddOrder(Order newOrder)
        {
            var response = await _orderService.AddOrder(newOrder);
            var data = NewOrderDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(Guid id, Order updOrder)
        {
            var response = await _orderService.EditOrder(id, updOrder);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _orderService.DeleteOrder(id);
            return Ok(response);
        }

    }
}
