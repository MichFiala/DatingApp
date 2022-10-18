using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly DataContext context;

	public UsersController(DataContext context)
	{
		this.context = context;
	}
	[HttpGet]
	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() =>  await context.Users.ToListAsync();

	[HttpGet("{id}")]
	public async Task<ActionResult<AppUser>> GetUser(string id) => await context.Users.FindAsync(id);
}
