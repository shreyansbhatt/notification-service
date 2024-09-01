using System.ComponentModel.DataAnnotations;
using Channel = NotificationService.Domain.Enums.Channel;

namespace NotificationService.Api.Models;

public class NotificationRequestDto
{
    [Required]
    public required Guid UserId { get; set; }

    [Required]
    public required Guid NotificationTypeId { get; set; }

    [Required]
    [EnumDataType(typeof(Channel))]
    public required Channel Channel { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Content length can't exceed 500 characters.")]
    public required string Content { get; set; }
}
