using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicantReview
    {
        [Key]
        public Guid ApplicantReviewId { get; set; }
        public Guid ApplicantId { get; set; }
        public string ClientComment { get; set; }
        public string ModerationComment { get; set; }
        public List<string> RejectLabels { get; set; }
        public string ReviewAnswer { get; set; }
        public string ReviewRejectType { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
