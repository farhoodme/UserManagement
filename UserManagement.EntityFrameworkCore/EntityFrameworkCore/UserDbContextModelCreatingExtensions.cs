using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Users;

namespace UserManagement.EntityFrameworkCore
{
    public static class UserDbContextModelCreatingExtensions
    {
        public static void ConfigureUsers(this ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.ToTable("Users");
                b.Property(i => i.Name).IsRequired();
                b.Property(i => i.Surname).IsRequired();
                b.Property(i => i.TCKN).IsRequired().HasMaxLength(UserConsts.MaxTCKNLength);
                b.HasIndex(i => i.TCKN).IsUnique();
            });
        }
    }
}
