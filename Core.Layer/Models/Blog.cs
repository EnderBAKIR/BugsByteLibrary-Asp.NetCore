using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Description { get; set; }


        public string Name { get; set; }

        public string Content { get; set; }

        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public int? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Status { get; set; }

        public bool InformationBlog { get; set; } = false; //Admin tarafından açılan bilgi verici blogların oluşturulması ve listelenmesi için
        public bool CodeBank { get; set; } = false; //Admin tarafından açılan Kod Bankası bloglarının oluşturulması ve listelenmesi için

        public ICollection<Comment> Comments { get; set; }

        public ICollection<BlogCategory> BlogCategories { get; set; }

        
    }
}
