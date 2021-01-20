using System;
using System.ComponentModel.DataAnnotations;

namespace Gerardo_BLOG.Models
{
    public class Post : BlogObject
    {
        ///Validation used Data Annotations and Unobtrusive
        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Pub Date field is required")]
        [DataType(DataType.Date)]
        public DateTime? publicationDate { get; set; }

        [Display(Prompt="Min. 10 characters")]
        [Required(ErrorMessage = "The content field is required")]
        [MinLength(10, ErrorMessage = "Min. 10 characters")]
        public string contents { get; set; }
        
        [Required(ErrorMessage = "Select a valid category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set;}

    }
}