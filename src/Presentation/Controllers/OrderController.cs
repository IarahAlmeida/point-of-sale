using Application.InputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(ILogger<OrderController> logger, IOrderService orderService) : ControllerBase
{
    private readonly ILogger<OrderController> _logger = logger;
    private readonly IOrderService _orderService = orderService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderService.GetById(id);

        if (order == null)
        {
            _logger.LogInformation("Order {id} not found.", id);
            return NotFound();
        }

        _logger.LogInformation("Returning order {id}.", id);
        return Ok(order);
    }

    [HttpPost(Name = "CreateOrder")]
    public async Task<IActionResult> Post([FromBody] OrderInputModel inputModel)
    {
        try
        {
            var id = await _orderService.Create(inputModel);
            _logger.LogInformation("Order {id} created.", id);
            return CreatedAtAction(nameof(Get), new { id }, inputModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);
            return BadRequest(e.Message);
        }
    }
}