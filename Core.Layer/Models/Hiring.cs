using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class Hiring
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<OpenToWork> OpenToWorks { get; set; }
    }
}
