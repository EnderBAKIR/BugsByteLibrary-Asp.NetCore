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
    internal class CourseCodeConfiguration : IEntityTypeConfiguration<CourseCode>
    {
        public void Configure(EntityTypeBuilder<CourseCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser).WithMany(x => x.CourseCodes).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Cascade); // Eğer user silinirse ona ait kurs kodlarıda silinsin => bu kodların silinmesi site yapısını etkilemiyeceğinden silinmesine izin verildi.
        }
    }
}
