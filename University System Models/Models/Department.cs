using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace University_System_Models.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]  // put it outside the class
    internal class Department
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //i need this because the value is created automatically by the database/system, not entered by the user.
        public int DepartmentId { get; set; }  // system generated
        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }  // user input
        [MaxLength(50)]
        public string Building { get; set; }  // user input
        [Required]
        [Range(typeof(decimal), "0", "100000")] // Range validation for decimal values , i need to mention "type of" because the range most uses with double si i need to specify that i want type of decimal
        public decimal Budget { get; set; }  // user input

        [ForeignKey("Instructor")] // name of navigation properties
        public int? HeadInstructorId { get; set; }  //from list // foreign key from Instructor class  // int? (can be null) becuase (no head instructor yet).
        public Instructor Instructor { get; set; } // Navigation property // like connect both 
        public ICollection<Course> Courses { get; set; } // Navigation property  // many courses

    }
}
