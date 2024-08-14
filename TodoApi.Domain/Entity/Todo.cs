using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Domain.Entity;

[Table("todos")]
public class Todo
{
    [Key] [Column("todo_id")] public int Id { get; set; }

    [Column("todo_name")] public string Name { get; set; }

    [Column("todo_is_complete")] public bool IsComplete { get; set; }
}