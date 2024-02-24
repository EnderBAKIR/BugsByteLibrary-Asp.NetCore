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
    public class OpenToWorkConfiguration : IEntityTypeConfiguration<OpenToWork>
    {
        public void Configure(EntityTypeBuilder<OpenToWork> builder)
        {
            builder.HasKey(x => x.Id);
            


            builder.HasOne(x => x.AppUser).WithMany(x => x.OpenToWorks).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);//User silinsin ama ona ait İş Başvuruları(OpenToWork.cs)  ileriye dönük işçi arama işlemleri için böyle bir karar alındı.
        }
    }
}
