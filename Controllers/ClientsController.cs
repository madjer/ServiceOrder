using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ClientsController : ControllerBase
	{
		private readonly DataContext _context;
		public ClientsController(DataContext context)
		{
			_context = context;
		}
		// GET api/clients
		[HttpGet]
		public async Task<ActionResult> GetClients()
		{
			var clients = await _context.Clients.ToListAsync();
			return Ok(clients);
		}

		// GET api/clients/5
		[HttpGet("{id}")]
		public async Task<ActionResult> GetClient(int id)
		{
			var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
			return Ok(client);
		}

		// POST api/clients
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/clients/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/clients/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
