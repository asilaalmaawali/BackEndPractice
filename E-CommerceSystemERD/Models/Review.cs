using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Review
    {

        public int reviewId { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public DateTime reviewDate { get; set; }

    }
}
