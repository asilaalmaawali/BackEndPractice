using System;
using System.Collections.Generic;
using System.Text;

namespace University_System_Models.Models
{
    internal class Department
    {
        public int DepartmentId { get; set; }  // system generated
        public string DepartmentName { get; set; }  // user input
        public string Building { get; set; }  // user input
        public decimal Budget { get; set; }  // user input
        public int HeadInstructorId { get; set; }  //from list // foreign key from Instructor class

    }
}
