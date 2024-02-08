namespace Amdax.Dtos.SumSub
{
    public class ApplicantReviewedDto
    {
        public Guid SumSubApplicantId { get; set; }
        public string ExternalUserId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTimeOffset CreatedAtMs { get; set; }
        public string InspectionId { get; set; }
        public string LevelName { get; set; }
        public string ReviewStatus { get; set; }
        public string Type { get; set; }
        public string ClientComment { get; set; }
        public string ModerationComment { get; set; }
        public List<string> RejectLabels { get; set; }
        public string ReviewAnswer { get; set; }
        public string ReviewRejectType { get; set; }
    }
}
