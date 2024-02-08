using Amdax.Controllers;

using AutoFixture;

using MediatR;

using Microsoft.Extensions.Logging;

using NSubstitute;

using Xunit;

namespace Tests
{
    [TestClass]
    public class ApplicantControllerTest
    {
        private readonly IFixture _fixture;
        private readonly IMediator _mediator;
        private readonly ILogger<ApplicantController> _logger;

        private ApplicantController applicantController;
        public ApplicantControllerTest()
        {
            _logger = Substitute.For<ILogger<ApplicantController>>();
            _mediator = Substitute.For<Mediator>();

            applicantController = new ApplicantController(_logger, _mediator);
        }

        [Fact]
        public void WebHookCreateApplicant_ValidObject_ShouldCreateApplicant()
        {

        }
    }
}