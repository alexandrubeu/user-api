using PersonsApi.DTOs;
using PersonsApi.Models;

namespace PersonsApi.Repositories;

public class UserRepository
{
    private readonly List<EUser> _users = [];

    public UserRepository()
    {
        _users.Add(new EUser()
        {
            Id = 1,
            Email = "Student1@stundet.com",
            Profile = new EProfile()
            {
                Id = 1,
                Age = 25,
                Company = "Nerds.sh",
                Name = "Cool Student",
            }
        });
        _users.Add(new EUser()
        {
            Id = 2,
            Email = "Studentescu@student.com",
            Profile = new EProfile()
            {
                Id = 2,
                Age = 25,
                Company = "Nerds.sh",
                Name = "Cool Student",
            }
        });
    }

    public Pagination<EUser> Get(string? term, PaginationParam paginationParam)
    {
        var persons = _users.AsEnumerable();
        if (term != null)
        {
            persons = persons.Where(z => z.Email.ToLower().Contains(term.ToLower()));
        }
        
        return persons.ToPagination(paginationParam);
    }

    public EUser Get(int id)
    {
        return _users.Single(z => z.Id == id);
    }


    public EUser Add(EUser user)
    {
        var lastUserInserted = _users.MaxBy(z => z.Id);
        user.Id = lastUserInserted.Id + 1;
        _users.Add(user);
        return this.Get(user.Id);
    }


    public EUser Update(EUser eUser)
    {
         var user = this.Get(eUser.Id);
        user.Profile = eUser.Profile;
        user.Email = eUser.Email;

        return this.Get(user.Id);
    }

    public void Delete(int id)
    {
        var person = this.Get(id);
        _users.Remove(person);
    }
}