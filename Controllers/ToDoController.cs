using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;
using ToDoServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using ToDoWeb.DTO;
using System.Collections.Generic;
// using ToDoWeb.Models;

namespace ToDoWeb.Controllers
{
  [ApiController]
  [Route("api/todo")]
  public class ToDoController : ControllerBase
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ToDoController(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    //Post: api/todo/create
    [HttpPost]
    [Route("create")]
    public IActionResult Create(ToDo todo)
    {
      _context.ToDos.Add(todo);
      _context.SaveChanges();
      var todoDTO = _mapper.Map<ToDoDTO>(todo);
      return Created("", todoDTO);
    }

    [HttpGet]
    [Route("list")]
    public IActionResult List()
    {
      var toDos = _context.ToDos.Include(i => i.Category).ToList();
      var toDosDTO = _mapper.Map<List<ToDoDTO>>(toDos);

      return Ok(toDosDTO);

    }
    // public IActionResult List() => Ok(_context.ToDos.ToList());

    [HttpGet]
    [Route("getById/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      ToDo todo = _context.ToDos.Find(id);
      if (todo == null)
      {
        return NotFound();
      }
      var todoDTO = _mapper.Map<ToDoDTO>(todo);
      return Ok(todoDTO);
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
      _context.ToDos.Remove(todo);
      _context.SaveChanges();
      var toDos = _context.ToDos.ToList();
      return Ok(_mapper.Map<List<ToDoDTO>>(toDos));
    }

    [HttpPut]
    [Route("update/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] ToDo todo)
    {
      todo.Id = id;
      // todo.CategoryId = _context.ToDos.Find(todo.Id).CategoryId;
      //Console.WriteLine(todo);
      _context.ToDos.Update(todo);
      _context.SaveChanges();
      var toDos = _context.ToDos.ToList();
      return Ok(_mapper.Map<List<ToDoDTO>>(toDos));
    }
  }
}
