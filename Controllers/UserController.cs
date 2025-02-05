using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Together2._0.Data;
using Together2._0.Models;

namespace Together2._0.Controllers;
[Route("api/[controller]")]


public class UserController: ControllerBase
{
    private readonly ILogger<UserController>_logger;
    private readonly TogetherDbContext _context;

    public UserController(ILogger<UserController> logger, TogetherDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetUsers")]

    public async Task<IActionResult> GetUsers()
    {
        var allUsers = await  _context.Users.ToListAsync();
        return Ok(allUsers);

    }

    [HttpGet("GetActiveUser")]
    public async Task<IActionResult> GetActiveUser()
    {
        var user = await  _context.Users.FirstOrDefaultAsync(u => u.ActiveUser);

        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            
            return NotFound();
        }

        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        

       
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

       
        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
    }
}