using LMS_Backend.Data;
using LMS_Backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly DataContext dataContext_;
    public UserController(DataContext dataContext)
    {
        dataContext_ = dataContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await dataContext_.Users.ToListAsync();
        return users;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return await dataContext_.Users.FindAsync(id);
    }




}