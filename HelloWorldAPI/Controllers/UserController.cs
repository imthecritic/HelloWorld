using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.API.Models;
using System.Linq;

namespace HelloWorld.API.Controllers
{
	[Route("api/Users")]
	public class UserController : Controller
	{
		private readonly UserContext _context;

		public UserController(UserContext context)
		{
			_context = context;

			if (_context.Users.Count() == 0)
			{
                _context.Users.Add(new User
                {
                    firstName = "John",
                    lastName = "Doe",
                    email = "johndoe@email.com",
                    birthdate = new DateTime(1970,01,01) });
				_context.SaveChanges();
			}
		}



		[HttpGet]
		public IEnumerable<User> GetAll()
		{
			return _context.Users.ToList();
		}

		[HttpGet("{id}", Name = "GetUser")]
		public IActionResult GetById(long id)
		{
			var item = _context.Users.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] User user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			_context.Users.Add(user);
			_context.SaveChanges();

			return CreatedAtRoute("GetUser", new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] User user)
		{
			if (user == null || user.Id != id)
			{
				return BadRequest();
			}

			var current = _context.Users.FirstOrDefault(t => t.Id == id);
			if (current == null)
			{
				return NotFound();
			}

			current.firstName = user.firstName;
			current.lastName = user.lastName;
			current.birthdate = user.birthdate;
			current.email = user.email;


			_context.Users.Update(current);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var user = _context.Users.FirstOrDefault(t => t.Id == id);
			if (user == null)
			{
				return NotFound();
			}

			_context.Users.Remove(user);
			_context.SaveChanges();
			return new NoContentResult();
		}

	}
}