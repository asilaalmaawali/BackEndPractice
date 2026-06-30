using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Instructor
    {

        public int InstructorId { get; set; }  // system generated
        public string FullName { get; set; }  // user input
        public string Email { get; set; }  // user input
        public string OfficeNumber { get; set; }  // user input
        public DateTime HireDate { get; set; }  // System generated (because we will use (date.now)method)

        public decimal Salary { get; set; }  // Calculated

        public string AcademicTitle { get; set; }  // user input


    }
}
