using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyQuesion.Models
{
    public class Survey
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullNames { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DOBValidation(ErrorMessage = "Age must be between 5 and 120.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [Required]
        public bool Food1 { get; set; }

        [Required]
        public bool Food2 { get; set; }

        [Required]
        public bool Food3 { get; set; }

        [Required]
        public bool Food4 { get; set; }

        [Required]
        public int Movies { get; set; }

        [Required]
        public int Radio { get; set; }

        [Required]
        public int EatOut { get; set; }

        [Required]
        public int TV { get; set; }
    }
     public class DOBValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateOfBirth = (DateTime)value;
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

            return age >= 5 && age <= 120;
        }
    }
}