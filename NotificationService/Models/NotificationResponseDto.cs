namespace NotificationService.Api.Models;

public class NotificationResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid NotificationTypeId { get; set; }
    public required string Channel { get; set; }
    public required string Content { get; set; }
    public DateTime SentDate { get; set; }
    public required string Status { get; set; }
}
