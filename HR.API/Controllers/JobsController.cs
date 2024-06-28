using AutoMapper;
using FluentValidation;
using HR.API.Services;
using HR.Application.Contracts;
using HR.Domain.Dtos;
using HR.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers
{
    [Route("api/v1/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IMessageProducer _messageProducer;
        private readonly IJobService _jobservice;
        private readonly IMapper _mapper;
        private readonly IValidator<JobDto> _validator;

        public JobsController(ILogger<JobsController> logger, IMessageProducer messageProducer, IJobService jobService, IMapper mapper, IValidator<JobDto> validator)
        {
            _logger = logger;
            _messageProducer = messageProducer;
            _jobservice = jobService;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// /Action method to get all jobs.
        /// </summary>
        /// <returns>A list with all jobs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _jobservice.GetJobsAsync();
            var result = _mapper.Map<IEnumerable<JobDto>>(jobs);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new job.
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJob(JobDto requestBody) 
        {
            var validationResult = await _validator.ValidateAsync(requestBody);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            var job = _mapper.Map<Job>(requestBody);
            await _jobservice.CreateJob(job);

            _messageProducer.SendingMessage(requestBody);

            return new JsonResult(requestBody) { StatusCode = 201};
        }
    }
}
