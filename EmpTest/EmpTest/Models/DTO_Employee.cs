using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpTest.Models
{
    public class DTO_Employee
    {
        [ScaffoldColumn(false)] // ScaffoldColumn - Allows hiding fields from editor forms
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public long Salary { get; set; }
        [Required(ErrorMessage = "Join Date is required")]
        [ValidateDateRange]
        public DateTime Joindate { get; set; }






        public class ValidateDateRange : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime dt = Convert.ToDateTime(value);
                // your validation logic
                if (dt >= Convert.ToDateTime("01/10/2008"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date is not in given range.");
                }
            }
        }
    }
}
