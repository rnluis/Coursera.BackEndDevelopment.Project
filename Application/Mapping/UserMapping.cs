namespace Application.Mapping;

using Application.User;

public static class UserMapping
{
    /// <summary>
    /// Map domain User to UserDto
    /// </summary>
    public static UserDto ToDto(Domain.Users.User user)
        => new(user.Id,user.FirstName, user.LastName, user.Email);

    /// <summary>
    /// Create a domain User from a CreateUserCommand
    /// </summary>
    public static Domain.Users.User ToDomain(UserDto dto)
        => Domain.Users.User.Create(dto.FirstName, dto.LastName, dto.Email);
    
    public static List<UserDto> ToDtoList (List<Domain.Users.User> users)
    {
        List<UserDto> usersDto = new List<UserDto>();
        
        foreach (var entity in users)
        {
            usersDto.Add((UserDto)ToDto(entity));
        }

        return usersDto;
    }

}