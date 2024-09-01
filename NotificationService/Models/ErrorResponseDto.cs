namespace NotificationService.Api.Models;

public class ErrorResponseDto
{
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = [];
}
