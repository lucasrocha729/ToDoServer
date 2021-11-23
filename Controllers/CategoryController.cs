using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;
using ToDoServer.Models;
using ToDoWeb.DTO;

namespace ToDoServer.Controllers
{
  [ApiController]
  [Route("api/category")]
  public class CategoryController : ControllerBase
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CategoryController(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
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
    public IActionResult List()
    { 
      var categories = _context.Category.ToList()
      var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);

      return Ok(categoriesDTO);
    }

    [HttpGet]
    [Route("getById/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      Category category = _context.Category.Find(id);
      if (category == null)
      {
        return NotFound();
      }
      var categoryDTO = _mapper.Map<CategoryDTO>(category);
      return Ok(categoryDTO);
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
      var categories = _context.Category.ToList();
      return Ok(_mapper.Map<List<CategoryDTO>>(categories));
    }


    [HttpPut]
    [Route("update/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Category category)
    {
      category.Id = id;
      _context.Category.Update(category);
      _context.SaveChanges();
      var categories = _context.Category.ToList();
      return Ok(_mapper.Map<List<CategoryDTO>>(categories));
    }


  }
}
