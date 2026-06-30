using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University_System_Models.Models
{
    internal class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }  // system generated
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }  // user input
        [Required]
        [MaxLength(150)]
        //[Index(IsUnique = true)]// for unique
        public string Email { get; set; }  // user input
        [MaxLength(20)]
        public string PhoneNumber { get; set; }  // user input
        [Required]
        public DateTime DateOfBirth { get; set; }  // Calculated 
        [Required]
        [Range (2000, 2030) ]
        public int EnrollmentYear { get; set; }  // user input
        [Range(0.0, 4.0)]
        public decimal Gpa { get; set; } = 0.0m; //as default = 0.0  // m = decimal type


    }
}
