namespace Application.User;

public record UserDto
(
    Guid id,
    string FirstName,
    string LastName,
    string Email
);