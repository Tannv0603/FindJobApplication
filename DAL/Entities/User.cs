using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
#nullable disable

namespace DAL.Entities
{
    public partial class User:IdentityUser
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public short TypeUser { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
