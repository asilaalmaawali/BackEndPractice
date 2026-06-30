using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Course
    {
        public int CourseId { get; set; }  // system generated
        public string CourseCode { get; set; }  // system generated
        public string CourseTitle { get; set; }  // user input

        public int CreditHours { get; set; }  // user input
        public int DepartmentId { get; set; }  //from list // foreign key from Department class
        public int InstructorId { get; set; }   //from list // foreign key from Instructor class
        public string SemesterOffered { get; set; }  // user input

    }
}
