using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDatabase1.Models
{
    public class ProjectCategory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        public string CategoryName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;
    }
}
