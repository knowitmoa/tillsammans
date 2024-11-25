using System.Text.Json.Serialization;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace Together2._0.Models;

public class Activity
{
    [JsonIgnore] 
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string EventDay { get; set; } = null!;
    
    public string EventTime { get; set; } = null!;
    public int UserId { get; set; }
    public User Owner { get; set; } = null!;
    
    
    public ICollection<User> Participants { get; set; } = new List<User>();
    [JsonIgnore]
    public List<int> ParticipantIds { get; set; } = new List<int>();


}