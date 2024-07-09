namespace PersonsApi.DTOs;

public class DUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DProfile? Profile { get; set; }
}