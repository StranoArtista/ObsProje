using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class Syllabus_Configuration:BaseConfiguration<Syllabus>
    {
        public override void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.User).WithOne(x => x.Syllabus).HasForeignKey<Syllabus>(x => x.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
