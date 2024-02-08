using Domain.Models;

using FluentResults;

using Microsoft.Extensions.Logging;

using Service.Repositories.Context;
using Service.Repositories.Interfaces;

namespace Service.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ILogger<ApplicantRepository> logger;

        public ApplicantRepository(ILogger<ApplicantRepository> logger)
        {
            this.logger = logger;
        }

        public async Task<Result<int>> InsertApplicant(Applicant applicant)
        {
            try
            {
                using (AmdaxDbContext db = new())
                {
                    await db.Applicant.AddAsync(applicant);
                    var commitResult = await db.SaveChangesAsync();
                    return Result.Ok(commitResult);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error while inserting a new Applicant on the database",
                    ex,
                    DateTimeOffset.UtcNow);

                return Result.Fail(new Error(ex.Message));
            }
        }
    }
}
