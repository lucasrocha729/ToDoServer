using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;

namespace ToDoServer.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
       private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        //Post: api/status/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Status status)
        {
            _context.Status.Add (status);
            _context.SaveChanges();
            return Created("", status);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Status.ToList());

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Status status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            Status status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }
            _context.Status.Remove (status);
            _context.SaveChanges();
            return Ok(_context.Status.ToList());
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Status status)
        {
            status.Id = id;
            _context.Status.Update (status);
            _context.SaveChanges();
            return Ok(_context.Status.ToList());
        }
     }
}
