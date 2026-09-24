using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Dtos;

public class UpdateTodoDto
{
    [Required]
    [MaxLength(100)]
    public string Title {get; set;} = string.Empty;

    [MaxLength(500)]
    public string? Description {get; set; }

    public bool IsCompleted {get; set; }

    public DateTime? DueDate {get; set; }
}