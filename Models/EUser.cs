namespace PersonsApi.Models;

public class EUser
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public EProfile? Profile { get; set; }
    
}