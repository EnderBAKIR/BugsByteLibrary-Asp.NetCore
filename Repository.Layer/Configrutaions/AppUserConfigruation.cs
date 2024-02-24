using Core.Layer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Configrutaions
{
    internal class AppUserConfigruation : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.Ignore(x => x.Image);

            builder.HasMany(x => x.Blogs).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);//User silinsin ama ona ait bloglar silinmesin(sitenin veri bütünlüğünü sağlamak adına böyle bir karar alındı.)

            
           







        }
    }
}
