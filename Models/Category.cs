using System.ComponentModel.DataAnnotations;
namespace Gerardo_BLOG.Models
{
    ///
    ///Summary : Category model, inherits  from BlogObject
    ///Validation used Data Annotations and Unobtrusive
    public class Category : BlogObject
    {
        ///Validation used Data Annotations and Unobtrusive
        [Required]
        public string Title { get; set; }
    }
}