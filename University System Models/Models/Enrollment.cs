using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Enrollment
    {
        public int EnrollmentId { get; set; }  // system generated
        public int StudentId { get; set; }  //from list // foreign key from Student class
        public int CourseId { get; set; }  //from list // foreign key from Course class
        public DateTime EnrollmentDate { get; set; } // System generated (because we will use (date.now)method)

        public string FinalGrade { get; set; } // user input
        public string Status { get; set; } // as default "In Progress"
    }
}
