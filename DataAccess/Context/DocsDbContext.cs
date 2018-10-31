using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DocsDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Departament> Departament { get; set; }
        public DbSet<Docs> Docs { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DocsDbContext(DbContextOptions<DocsDbContext> options)
            : base(options)
        {
                   
        }
    }
}