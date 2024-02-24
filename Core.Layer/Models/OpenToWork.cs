using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class OpenToWork
    {
        public string Id { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public bool Status { get; set; }

        public string ApplicantName { get; set; }

        public string ApplicantAddress { get; set; }

        public string ApplicantPhone { get; set; }

        public string Description { get; set; }

        public string? CVPdfUrl { get; set; }

        [NotMapped]
        public IFormFile? CVPdf { get; set; }

        public string? HiringId { get; set; }

        public Hiring? Hiring { get; set; }

        public int? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }


    }
}
