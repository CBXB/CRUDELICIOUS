using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name of Dish")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "Chef Name is required")]
        [Display(Name = "Chef's Name")]

        public string ChefName { get; set; }

        [Required(ErrorMessage = "Please select a Tasting level")]
        [Display(Name = "Tastiness")]
        
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Select enter a # of Calories ")]
        [Display(Name = "Calories")]
        
        public int Calories { get; set; }

        [Required(ErrorMessage = "Please add a drescription")]
        [Display(Name = "Description")]
        [MinLength(20, ErrorMessage = "Comment must be at least 20 characters!")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;



    }
}