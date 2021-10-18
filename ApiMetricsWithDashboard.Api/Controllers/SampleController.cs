using ApiMetricsWithDashboard.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMetricsWithDashboard.Api.Controllers
{
    [ApiController]
    [Route("sample")]
    public class SampleController : ControllerBase
    {
        private static Dictionary<Guid, SampleDto> repository = new Dictionary<Guid, SampleDto>();

        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await GetAsync();
            return Ok(result);
        }

        private async Task<IEnumerable<SampleDto>> GetAsync()
        {
            return await Task.Run<IEnumerable<SampleDto>>(() => repository.Values.AsEnumerable());
        }
        private async Task<SampleDto> GetAsync(Guid id)
        {
            return await Task.Run<SampleDto>(() => { return repository[id]; });
        }

        [HttpGet("/{sampleId}")]
        public async Task<IActionResult> Get([FromRoute] Guid sampleId)
        {
            var result = await GetAsync(sampleId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SampleDto itemToCreate)
        {
            await CreateAsync(itemToCreate);
            return CreatedAtAction("GetSample", new { sampleId = itemToCreate.Id }, itemToCreate.Id);
        }

        private async Task CreateAsync(SampleDto itemToCreate)
        {
            await Task.Run(() => repository.Add(itemToCreate.Id, itemToCreate));
        }
    }
}
