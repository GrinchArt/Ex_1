using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentApi.Configuration;
using StudentApi.Models;

namespace StudentApi.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentApi.Models.Student> Student { get; set; } = default!;
        public DbSet<StudentApi.Models.Picture> Picture { get; set; } = default!;
		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.ApplyConfiguration(new PictureConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
		}
	}
}
