using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class Exam_Configuration:BaseConfiguration<Exam>
    {
        public override void Configure(EntityTypeBuilder<Exam> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.User_Exams).WithOne(x => x.Exam);
            builder.HasOne(x => x.Class).WithMany(x => x.Exams).HasForeignKey(x => x.ClassID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
