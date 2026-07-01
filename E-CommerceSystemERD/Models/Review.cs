using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Review
    {

        public int reviewId { get; set; } // system generated
        public int userId { get; set; } //from list //forign key
        public int productId { get; set; }  //from list //forign key
        public int rating { get; set; } //user input
        public string comment { get; set; } // user input
        public DateTime reviewDate { get; set; } // system generated

    }
}
