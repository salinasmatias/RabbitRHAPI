using HR.Application.Contracts;
using HR.Domain.Models;
using HR.Infrastructure.Repository;

namespace HR.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _repository;

        public JobService(IRepository<Job> repository)
        {
            _repository = repository;
        }

        public async Task CreateJob(Job job)
        {
            await _repository.CreateAsync(job);
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _repository.GetListAsync();
        }
    }
}
