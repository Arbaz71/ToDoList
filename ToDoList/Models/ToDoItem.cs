using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Models
{
    public class ToDoItem
    {
        [Key]
        public int ToDoItemId { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Priority { get; set; }
        public DueDate Date { get; set; }
        public bool IsComplete { get; set; }
        public string AddNotes { get; set; }
    }
}
