using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class LoginUser
    {
        [Key]
        public int LoginId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
