using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.EntityFrameworkCore
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureUsers();
        }
    }
}
