namespace Shared.Application.Events;

public class UserCreatedEvent
{
    public string? UserId { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserCreatedEvent(string? userId, string? email, DateTime createdAt)
    {
        UserId = userId;
        Email = email;
        CreatedAt = createdAt;
    }
};
