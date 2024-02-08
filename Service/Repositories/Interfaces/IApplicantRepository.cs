using Domain.Models;

using FluentResults;

namespace Service.Repositories.Interfaces
{
    public interface IApplicantRepository
    {
        Task<Result<int>> InsertApplicant(Applicant applicant);
    }
}
