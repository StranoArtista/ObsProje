using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProje.Models;

namespace ObsProje.Configurations
{
    public class User_Role_Configuration:BaseConfiguration<User_Role>
    {
        public override void Configure(EntityTypeBuilder<User_Role> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.UserId,
                x.RoleId
            });
        }
    }
}
