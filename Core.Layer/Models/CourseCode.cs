using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class CourseCode
    {
        public string Id { get; set; }
        public bool Status { get; set; }
        public string? Code { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string CourseId { get; set; }
        public CourseRequest CourseRequest { get; set; }


    }
}
