using System.ComponentModel.DataAnnotations;

namespace e_libraryProject.Models
{
    public class Author
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;


        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; }= string.Empty;



        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();


    }
}
