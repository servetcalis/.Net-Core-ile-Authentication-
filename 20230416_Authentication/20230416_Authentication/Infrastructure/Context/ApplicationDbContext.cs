
using _20230416_Authentication.Models.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // IdentityDbContext<> kullanımı için bu paketi yüklemeniz gerekmektedir.
using Microsoft.EntityFrameworkCore;
using _20230416_Authentication.Models.DTOs;

namespace _20230416_Authentication.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<_20230416_Authentication.Models.DTOs.LoginDTO> LoginDTO { get; set; }
        public DbSet<_20230416_Authentication.Models.DTOs.UserUpdateDTO> UserUpdateDTO { get; set; }
    }
}
