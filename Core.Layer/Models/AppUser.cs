using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public int ConfirmCode { get; set; }

        public ICollection<Comment> Comments { get; set; } 
        public ICollection<Blog> Blogs { get; set; }

        public ICollection<OpenToWork> OpenToWorks { get; set; }



    }


        
    
}

