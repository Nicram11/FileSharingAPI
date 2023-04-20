using FileSharingAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FileSharingAPI.Database
{
    public class FileSharingDbContext : IdentityDbContext<User>
    {
        public DbSet<FileHeader> Files { get; set; }

        public FileSharingDbContext(DbContextOptions<FileSharingDbContext> options) : base(options)
        {

        }
    }

}
