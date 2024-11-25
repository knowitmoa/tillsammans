using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together2._0.Data;
using Together2._0.Models;

namespace Together2._0.Controllers;

[Route("api/[controller]")]


public class ActivityController: ControllerBase
{
    private readonly ILogger<UserController>_logger;
    private readonly TogetherDbContext _context;
    
    

    public ActivityController(ILogger<UserController> logger, TogetherDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetActivities")]

    public async Task<IActionResult> GetActivities()
    {
        
        // Use Include to eagerly load related entities (Owner and Participants)
        var allActivities = await _context.Activities
            .Include(a => a.Owner) // Include the Owner (User)
            .Include(a => a.Participants) // Include the Participants (Users)
            .ToListAsync(); // Fetch the list of activities with related data

        return Ok(allActivities);

    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivities(int id)
    {
        
        var activity = await _context.Activities.FindAsync(id);

        if (activity == null)
        {
            return NotFound();
        }

        
        _context.Activities.Remove(activity);
        await _context.SaveChangesAsync();

        
        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult<Activity>> PostActivity(Activity activity)
    {
        // Validate that the owner exists by UserId
        var owner = await _context.Users.FindAsync(activity.UserId);
        if (owner == null)
        {
            throw new InvalidOperationException("The specified owner does not exist.");
        }

        activity.Owner = owner;
        
        
        foreach (var userId in activity.ParticipantIds)
        {
            var participant = await _context.Users.FindAsync(userId);  // Find user by ID
        
            if (participant == null)
            {
                throw new InvalidOperationException($"Participant with ID {userId} does not exist.");
            }
        
            activity.Participants.Add(participant);  // Add the found participant to the list
        }
        
        

  



        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

       
        return CreatedAtAction(nameof(GetActivities), new { id = activity.Id }, activity);
    }
    
    
}