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
    internal class CourseRequestConfiguration : IEntityTypeConfiguration<CourseRequest>
    {
        public void Configure(EntityTypeBuilder<CourseRequest> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.CourseCodes).WithOne(x => x.CourseRequest).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction);//Sitede ki kurslar silinirse kullanıcılara tanımlanan kodlar silinmesin > userların gelecek dönemde de bu kodları kullanabilmesi adına
        }
    }
}
