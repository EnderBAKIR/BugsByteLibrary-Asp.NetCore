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
    public class HiringConfiguration : IEntityTypeConfiguration<Hiring>
    {
        public void Configure(EntityTypeBuilder<Hiring> builder)
        {
            builder.HasKey(x => x.Id);
            


            builder.HasMany(x => x.OpenToWorks).WithOne(x => x.Hiring).HasForeignKey(x => x.HiringId).OnDelete(DeleteBehavior.NoAction);//Hiring silinsin fakat ona ait yapılan başvurular(OpenToWork.cs) silinmesin , ileriye dönük iş ağı oluşturmak için.

        }
    }
}
