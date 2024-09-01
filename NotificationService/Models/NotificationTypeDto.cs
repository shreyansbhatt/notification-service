using System.ComponentModel.DataAnnotations;

namespace NotificationService.Api.Models;

public class NotificationTypeDto
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Name length can't exceed 100 characters.")]
    public required string Name { get; set; }

    [StringLength(250, ErrorMessage = "Description length can't exceed 250 characters.")]
    public string? Description { get; set; }
}
