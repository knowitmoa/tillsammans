using System.Text.Json.Serialization;

namespace Together2._0.Models;

public class User
{
    [JsonIgnore] 
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Gender { get; set; } = null!;
    public bool ActiveUser { get; set; } = false;
    public String UserAdress { get; set;} 
}
    
    
    