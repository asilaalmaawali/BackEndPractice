using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Student
    {

        public int StudentId { get; set; }  // system generated
        public string FullName { get; set; }  // user input
        public string Email { get; set; }  // user input
        public string PhoneNumber { get; set; }  // user input
        public DateTime DateOfBirth { get; set; }  // Calculated 
        public int EnrollmentYear { get; set; }  // user input
        public decimal Gpa { get; set; }  //as default = 0


    }
}
