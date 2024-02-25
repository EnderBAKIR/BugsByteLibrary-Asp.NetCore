using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class CourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Price { get; set; } // kaç yoruma göre kodun verilceğini belirlemek için.

        public ICollection<CourseCode> CourseCodes { get; set; }
    }
}
