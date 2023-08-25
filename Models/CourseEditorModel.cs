using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewProjectEF.Models
{
    public class CourseEditorModel
    {
       

        [Required(ErrorMessage = "Please enter name of the Course")]
        [Display(Name = "CourseTitle")]
        public string? CourseTitle { get; set; }

        
        [Display(Name = "DurationInDays")]
        public int DurationInDays { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [HiddenInput]
        public int CourseId { get; set; }
        public int CourseID { get; internal set; }
        public bool? IsActive { get;  set; }
    }
}

