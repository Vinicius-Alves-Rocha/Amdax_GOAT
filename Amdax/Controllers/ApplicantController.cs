using Amdax.Dtos.SumSub;

using Domain.Mappers;
using Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Service.Commands;

using Amdax.Extensions;

namespace Amdax.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IMediator mediator;

        public ApplicantController(ILogger<ApplicantController> logger,
            IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost(Name = "Review/Result")]
        public async Task<IActionResult> ReceiveApplicantReview([FromBody] ApplicantReviewedDto applicantReviewedDto)
        {
            var domainApplicant = applicantReviewedDto.MapToDomain();

            var createApplicantReviewCommand = new CreateApplicantReviewCommand(domainApplicant);
            var result = await mediator.Send(createApplicantReviewCommand);

            return result.AsActionResult();
        }
    }
}
