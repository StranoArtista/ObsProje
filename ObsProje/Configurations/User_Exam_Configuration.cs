using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class User_Exam_Configuration:BaseConfiguration<User_Exam>
    {
        public override void Configure(EntityTypeBuilder<User_Exam> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.UserId,
                x.ExamId
            });
        }
    }
}
