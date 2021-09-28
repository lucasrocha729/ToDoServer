using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoServer.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public virtual List<ToDo> ToDo { get; set; }
  }



}
