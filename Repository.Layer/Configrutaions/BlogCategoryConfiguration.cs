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
    internal class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(x=> new {x.BlogId , x.CategoryId });

            builder.HasOne(x=>x.Blog).WithMany(x=>x.BlogCategories).HasForeignKey(x=>x.BlogId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category).WithMany(x => x.BlogCategories).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
