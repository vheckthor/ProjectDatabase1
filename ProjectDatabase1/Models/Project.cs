using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDatabase1.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Project Title is Required")]
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "Project Author is Required")]
        public string ProjectAuthor { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now.Date;

        //Relationships
        [ForeignKey("ProjectCategoryId")]
        [ValidateNever]
        public ProjectCategory ProjectCategory { get; set; }

        [Required(ErrorMessage ="Project category is required")]
        public int ProjectCategoryId { get; set; }

    }
}
