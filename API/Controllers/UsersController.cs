using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController : BaseApiController
{
	private readonly DataContext context;

	public UsersController(DataContext context)
	{
		this.context = context;
	}
	[AllowAnonymous]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() =>  await context.Users.ToListAsync();

	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<AppUser>> GetUser(string id) => await context.Users.FindAsync(id);
}
