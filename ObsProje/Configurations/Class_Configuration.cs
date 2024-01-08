using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class Class_Configuration:BaseConfiguration<Class>
    {
        public override void Configure(EntityTypeBuilder<Class> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.User_Classes).WithOne(x => x.Class);
            builder.HasMany(x => x.Exams).WithOne(x => x.Class);
        }
    }
}
