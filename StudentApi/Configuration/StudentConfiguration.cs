using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApi.Models;

namespace StudentApi.Configuration
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(x=>x.Id);

			builder.Property(x => x.Name)
				.IsRequired();

			builder.Property(x => x.Email)
				.IsRequired();

			builder.Property(x=>x.Group)
				.IsRequired(false);

			builder.Property(x=>x.Rate)
				.IsRequired();

		}
	}
}
