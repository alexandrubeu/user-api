using PersonsApi.DTOs;
using PersonsApi.Mappers;
using PersonsApi.Repositories;

namespace PersonsApi.Services;

public class PersonService
{
    private readonly UserRepository _userRepository = new();
    private readonly UserMapper _userMapper = new();

    public Pagination<DUser> Get(string? term, PaginationParam paginationParam)
    {
        var persons = _userRepository.Get(term, paginationParam);
        return new Pagination<DUser>()
        {
            Page = paginationParam.Page,
            PerPage = paginationParam.PerPage,
            Items = persons.Items.Select(person => _userMapper.ToDto(person)).ToList()
        };
    }

    public DUser Get(int id)
    {
        var person = _userRepository.Get(id);
        return _userMapper.ToDto(person);
    }

    public DUser Add(DUser p)
    {
        var personEntity = _userMapper.ToEntity(p);
        var updatedEntity =  _userRepository.Add(personEntity);

        return _userMapper.ToDto(updatedEntity);
    }

    public DUser Update(DUser dUser)
    {
        var updatedPersonEntity = _userRepository.Update(_userMapper.ToEntity(dUser));
        return _userMapper.ToDto(updatedPersonEntity);
    }

    public void Delete(int id) => _userRepository.Delete(id);
    
}