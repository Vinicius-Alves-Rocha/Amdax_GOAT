using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Applicant
    {
        [Key]
        public Guid ApplicantId { get; set; }
        public Guid SumSubApplicantId { get; set; }
        public string ExternalUserId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTimeOffset CreatedAtMs { get; set; }
        public string InspectionId { get; set; }
        public string LevelName { get; set; }
        public string ReviewStatus { get; set; }
        public string VerificationType { get; set; }

        public virtual ApplicantReview ApplicantReview { get; set; }
    }
}
