using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;
using ToDoServer.Models;
// using ToDoWeb.Models;

namespace ToDoWeb.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext _context;

        public ToDoController(DataContext context)
        {
            _context = context;
        }

        //Post: api/todo/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create(ToDo todo)
        {
            _context.ToDos.Add (todo);
            _context.SaveChanges();
            return Created("", todo);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.ToDos.ToList());

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            ToDo todo = _context.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            ToDo todo = _context.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            _context.ToDos.Remove (todo);
            _context.SaveChanges();
            return Ok(_context.ToDos.ToList());
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ToDo todo)
        {
            todo.Id = id;
            _context.ToDos.Update (todo);
            _context.SaveChanges();
            return Ok(_context.ToDos.ToList());
        }
    }
}
