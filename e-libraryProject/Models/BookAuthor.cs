using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_libraryProject.Models
{
    public class BookAuthor
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; } 

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; } 

        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
         public string? Note { get; set; }


    }
}
