using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAL.Entities
{
    public partial class Review
    {
        public int JobId { get; set; }
        [Key]
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public string UserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual Job Job { get; set; }
    }
}
