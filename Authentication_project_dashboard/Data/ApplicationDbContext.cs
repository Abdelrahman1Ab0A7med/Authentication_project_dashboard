using Authentication_project_dashboard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication_project_dashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book>? _book { get; set; }
        public DbSet<ApplicationUser>? _user { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public ApplicationDbContext()
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		  optionsBuilder.UseSqlServer("Data Source =ABDOLABTOP;Initial Catalog = Authentication_project_dashboard ;Integrated Security = True ;TrustServerCertificate=True; ");
	}
}