using Amdax.Dtos.SumSub;

using Domain.Models;

namespace Domain.Mappers
{
    public static class ApplicantReviewMapper
    {
        public static Applicant MapToDomain(this ApplicantReviewedDto applicantDto)
        {
            return new Applicant
            {
                SumSubApplicantId = applicantDto.SumSubApplicantId,
                ExternalUserId = applicantDto.ExternalUserId,
                CorrelationId = applicantDto.CorrelationId,
                CreatedAtMs = applicantDto.CreatedAtMs,
                InspectionId = applicantDto.InspectionId,
                LevelName = applicantDto.LevelName,
                ReviewStatus = applicantDto.ReviewStatus,
                VerificationType = applicantDto.Type,
                ApplicantReview = applicantDto.MapApplicantReview()
            };
        }

        public static ApplicantReview MapApplicantReview(this ApplicantReviewedDto applicantDto)
        {
            return new ApplicantReview
            {
                ClientComment = applicantDto.ClientComment,
                ModerationComment = applicantDto.ModerationComment,
                RejectLabels = applicantDto.RejectLabels,
                ReviewAnswer = applicantDto.ReviewAnswer,
                ReviewRejectType = applicantDto.ReviewRejectType
            };
        }
    }
}
