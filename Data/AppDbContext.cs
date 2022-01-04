using Microsoft.EntityFrameworkCore;
using ProjectTypeService.Models;

namespace ProjectTypeService.Data
{
    public class AppDbContext : DbContext
    {
        // Pont entre notre model et notre BDD
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt){}

        public DbSet<ProjectType> projectType {get; set;}
    }
}