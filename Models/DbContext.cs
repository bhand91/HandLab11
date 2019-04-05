using Microsoft.EntityFrameworkCore;

namespace HandLab11.Models
{
	public class ProfessorDbContext : DbContext
	{
		public ProfessorDbContext (DbContextOptions<ProfessorDbContext> options)
			: base(options)
		{
		}
		public DbSet<Professor> Professor {get; set;}
	}
}