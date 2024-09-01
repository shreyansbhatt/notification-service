using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Interfaces;
using NotificationService.Application.Commands;
using NotificationService.Application.Queries;

namespace NotificationService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationTypeController : ControllerBase
{
    private readonly INotificationTypeService _notificationTypeService;

    public NotificationTypeController(INotificationTypeService notificationTypeService)
    {
        _notificationTypeService = notificationTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotificationType([FromBody] CreateNotificationTypeCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _notificationTypeService.CreateNotificationTypeAsync(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return CreatedAtAction(nameof(GetNotificationTypeById), new { id = result.Data.Id }, result.Data);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateNotificationType(Guid id, [FromBody] UpdateNotificationTypeCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _notificationTypeService.UpdateNotificationTypeAsync(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return Ok(result.Data);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteNotificationType(Guid id)
    {
        var command = new DeleteNotificationTypeCommand (id);
        var result = await _notificationTypeService.DeleteNotificationTypeAsync(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNotificationTypeById(Guid id)
    {
        var query = new GetNotificationTypeByIdQuery(id);
        var result = await _notificationTypeService.GetNotificationTypeByIdAsync(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllNotificationTypes()
    {
        var result = await _notificationTypeService.GetAllNotificationTypesAsync();

        return Ok(result);
    }
}
