using HR.Domain.Models;

namespace HR.Application.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task CreateJob(Job job);
    }
}
