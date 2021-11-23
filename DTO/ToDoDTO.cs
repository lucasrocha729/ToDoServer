using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWeb.DTO
{
  public class ToDoDTO
  {
    public int Id { get; set; }
    public string ToDoName { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ToDoDate { get; set; }
    public DateTime ToDoDateEnd { get; set; }
    public string ToDoStatus { get; set; }
    public Boolean AllDay { get; set; }

    public int CategoryId { get; set; }

    public virtual CategoryDTO Category { get; set; }

  }
}
