using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Student
    {

        public int StudentId { get; set; }  // system generated
        public string fullName { get; set; }  // user input
        public string email { get; set; }  // user input
        public string phoneNumber { get; set; }  // user input
        public DateTime dateOfBirth { get; set; }  // Calculated 
        public int enrollmentYear { get; set; }  // user input
        public decimal gpa { get; set; }  //as default = 0



    }
}
