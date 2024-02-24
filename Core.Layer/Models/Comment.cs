using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentContent { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Status { get; set; }

        public int? BlogId { get; set; }
        public Blog? Blog { get; set; }

        public int? AppUserId { get; set; }
        public AppUser? Appuser { get; set; }

    }
}
