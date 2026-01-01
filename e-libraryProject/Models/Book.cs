using NuGet.Configuration;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;




namespace e_libraryProject.Models
{
    public class Book
    {


        [Key]
        [Required]
        public int Id { get; set; }



        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        

    

        

        [Required]
        public EBookStatus Status { get; set; }



        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();


    }


  



}
