using Microsoft.EntityFrameworkCore;
using System;

namespace FileSharingAPI.Entities
{
    public class FileSharingDbContext : DbContext
    {
        public DbSet<FileHeader> Files { get; set; }
        public DbSet<User> Users { get; set; }

    }
  
}
