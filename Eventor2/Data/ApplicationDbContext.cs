﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Eventor2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public System.Data.Entity.DbSet<Eventor2.Models.TicketModels> TicketModels { get; set; }
    }
}