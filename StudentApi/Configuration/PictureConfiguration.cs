using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApi.Models;

namespace StudentApi.Configuration
{
	public class PictureConfiguration : IEntityTypeConfiguration<Picture>
	{
		public void Configure(EntityTypeBuilder<Picture> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne<Student>()
			.WithMany()
			.HasForeignKey(x => x.StudentId);
			builder.Property(x => x.ImageData).IsRequired(false);
		}
	}
}
