using PersonsApi.DTOs;
using PersonsApi.Models;

namespace PersonsApi.Mappers;

public class ProfileMapper
{
    public DProfile ToDto(EProfile profile)
    {
        return new DProfile()
        {
            Id = profile.Id,
            Age = profile.Age,
            Name = profile.Name,
            Company = profile.Company
        };
    }

    public EProfile ToEntity(DProfile dProfile)
    {
        return new EProfile()
        {
            Id = dProfile.Id,
            Age = dProfile.Age,
            Company = dProfile.Company,
            Name = dProfile.Name,
        };
    }
}