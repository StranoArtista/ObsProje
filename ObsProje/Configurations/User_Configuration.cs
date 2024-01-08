using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class User_Configuration:BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasMany(x => x.User_Roles).WithOne(x => x.User).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasMany(x => x.User_Classes).WithOne(x => x.User).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasMany(x => x.User_Exams).WithOne(x => x.User).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasOne(x => x.Syllabus).WithOne(x => x.User).HasForeignKey<User>(x => x.SyllabusId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
