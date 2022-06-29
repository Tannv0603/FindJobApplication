using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual User User { get; set; }
        public virtual Job Job { get; set; }
    }
}
