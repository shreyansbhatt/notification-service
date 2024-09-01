using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Tests.Domain.Entities;

[TestClass]
public class NotificationTests
{
    [TestMethod]
    public void MarkAsSent_ChangesStatusToSent()
    {
        // Arrange
        var notification = new Notification(Guid.NewGuid(), Guid.NewGuid(), Channel.Email, "Test Content");

        // Act
        notification.MarkAsSent();

        // Assert
        Assert.AreEqual("Sent", notification.Status);
    }

    [TestMethod]
    public void MarkAsFailed_ChangesStatusToFailed()
    {
        // Arrange
        var notification = new Notification(Guid.NewGuid(), Guid.NewGuid(), Channel.Email, "Test Content");
        var failureReason = "Network error";

        // Act
        notification.MarkAsFailed(failureReason);

        // Assert
        Assert.AreEqual($"Failed: {failureReason}", notification.Status);
    }
}
