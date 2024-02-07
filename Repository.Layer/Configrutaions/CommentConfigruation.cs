using Core.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Configrutaions
{
    internal class CommentConfigruation : IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.HasOne(x=>x.Appuser).WithMany(x=> x.Comments).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }


    }
}
