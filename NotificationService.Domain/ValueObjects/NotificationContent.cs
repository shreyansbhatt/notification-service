namespace NotificationService.Domain.ValueObjects;

public class NotificationContent
{
    public string Content { get; }

    public NotificationContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty or whitespace.", nameof(content));

        if (content.Length > 500)
            throw new ArgumentException("Content cannot exceed 500 characters.", nameof(content));

        Content = content;
    }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is NotificationContent other)
        {
            return Content == other.Content;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Content.GetHashCode();
    }

    public static bool operator ==(NotificationContent left, NotificationContent right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(NotificationContent left, NotificationContent right)
    {
        return !(left == right);
    }
}
