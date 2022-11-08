using System.ComponentModel.DataAnnotations;

namespace BlazorExercises.Entities
{
    public class TodoItem
    {
        [Required]
        public string Title { get; set; }
        public string? Desc { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
