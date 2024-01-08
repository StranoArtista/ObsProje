using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class User_Class_Configuration:BaseConfiguration<User_Class>
    {
        public override void Configure(EntityTypeBuilder<User_Class> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x=> new
            {
                x.UserId,
                x.ClassId
            });
        }
    }
}
