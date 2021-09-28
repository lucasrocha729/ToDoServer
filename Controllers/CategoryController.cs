using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;
using ToDoServer.Models;

namespace ToDoServer.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase {
       private readonly DataContext _context;
        public CategoryController(DataContext context){
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return Created("", category);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Category.ToList());

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Category category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            Category category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
            return Ok(_context.Category.ToList());
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Category category)
        {
            category.Id = id;
            _context.Category.Update(category);
            _context.SaveChanges();
            return Ok(_context.Category.ToList());
        }


     }
}
