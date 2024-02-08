using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using baigiamasis2.Models;
using Image = baigiamasis2.Models.Image;

namespace baigiamasis2.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdress> UserAdress { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<LoginInfo> LoginInfo { get; set; }


        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
