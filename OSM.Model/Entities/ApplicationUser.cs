using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSM.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Hung Ly - add more User Info to manage besides others properties in IdentityUser

        [MaxLength(250)]
        public string FullName { set; get; }

        [MaxLength(250)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public virtual IEnumerable<Order> Orders { set; get; }
    }
}