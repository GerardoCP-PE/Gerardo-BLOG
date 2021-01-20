using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerardo_BLOG.Models
{
    ///
    ///Sumary : This class if for defined and Identity primary key for Category and Post model
    public abstract class BlogObject 
    {   
        //Identity field - primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=1)]
        public int Id { get; set; }         
        public BlogObject()
        {
            
        }
    }
}