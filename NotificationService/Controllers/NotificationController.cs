using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Interfaces;
using NotificationService.Application.Commands;
using NotificationService.Application.Queries;

namespace NotificationService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _notificationService.SendNotificationAsync(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok(result.Data);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNotificationById(Guid id)
    {
        var query = new GetNotificationByIdQuery (id);
        var result = await _notificationService.GetNotificationByIdAsync(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllNotifications([FromQuery] GetAllNotificationsQuery query)
    {
        var result = await _notificationService.GetAllNotificationsAsync(query);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        var command = new DeleteNotificationCommand(id);
        var result = await _notificationService.DeleteNotificationAsync(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }
}
