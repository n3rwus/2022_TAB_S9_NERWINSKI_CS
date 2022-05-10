using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Infrastructure.Data
{
    public class TabContext : DbContext
    {
        public TabContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Folder> Folders {get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
