
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monafasati.Data
{
    public class MonafasatiDbContext :IdentityDbContext
    {
        public MonafasatiDbContext(DbContextOptions<MonafasatiDbContext> options)
            :base(options)
        {


    }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Monafsa> Monafsas { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
