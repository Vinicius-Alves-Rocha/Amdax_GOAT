using Domain.Models;

using FluentResults;

using MediatR;

using Microsoft.Extensions.Logging;

using Service.Repositories.Interfaces;

namespace Service.Commands
{
    public class CreateApplicantReviewCommand : IRequest<Result<int>>
    {
        public Applicant Applicant { get; set; }

        public CreateApplicantReviewCommand(Applicant applicant)
        {
            Applicant = applicant;
        }

        public class CreateApplicantReviewCommandHandler : IRequestHandler<CreateApplicantReviewCommand, Result<int>>
        {
            private readonly IApplicantRepository applicantRepository;
            private readonly ILogger<CreateApplicantReviewCommandHandler> logger;

            public CreateApplicantReviewCommandHandler(IApplicantRepository applicantRepository,
                ILogger<CreateApplicantReviewCommandHandler> logger)
            {
                this.applicantRepository = applicantRepository;
                this.logger = logger;
            }

            public async Task<Result<int>> Handle(CreateApplicantReviewCommand request, CancellationToken cancellationToken)
            {
                logger.LogInformation("Handling the creation of a new Applicant",
                    request.Applicant.SumSubApplicantId);

                var result = await applicantRepository.InsertApplicant(request.Applicant);

                if (result.IsFailed || result.ValueOrDefault <= 0)
                {
                    return result.ToResult();
                }

                logger.LogInformation("New Applicant created successfully",
                    request.Applicant.SumSubApplicantId);

                return result.ToResult();
            }
        }
    }
}
