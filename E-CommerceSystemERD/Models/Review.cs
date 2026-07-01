using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Review
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; } // system generated
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; } //from list //forign key
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }  //from list //forign key
        [Required]
        [Range(1,5)]
        public int Rating { get; set; } //user input
        [MaxLength(1000)]
        public string? Comment { get; set; } // user input
        [Required]
        public DateTime ReviewDate { get; set; } // system generated

        public Product Product { get; set; } // navigation property // for one // relation : Product - Review
        public User User { get; set; } // navigation property // for one // relation : User - Review
    }
}
