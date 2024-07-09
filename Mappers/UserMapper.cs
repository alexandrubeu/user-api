using PersonsApi.DTOs;
using PersonsApi.Models;

namespace PersonsApi.Mappers;

public class UserMapper
{
    private readonly ProfileMapper _profileMapper = new();

    public DUser ToDto(EUser user)
    {
        return new DUser
        {
            Id = user.Id,
            Email = user.Email,
            Profile = user.Profile == null ? null : _profileMapper.ToDto(user.Profile)
        };
    }

    public EUser ToEntity(DUser dUser)
    {
        return new EUser()
        {
            Email = dUser.Email,
            Id = dUser.Id,
            Profile = dUser.Profile != null ? _profileMapper.ToEntity(dUser.Profile) : null
        };
    }
}