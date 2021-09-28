using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoServer.Models
{
  public class ToDo
  {
    public ToDo() => CreationDate = DateTime.Now;

    [Key]
    public int Id { get; set; }
    public string ToDoName { get; set; }

    public string Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ToDoDate { get; set; }

    public string ToDoStatus { get; set; }

    public override string ToString()
    {
      return $"Nome do ToDo: {ToDoName} | Descrição do ToDo {Description} | Criado em do ToDo {CreationDate} ";
    }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }





}
}