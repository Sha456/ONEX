using Hahn.ApplicationProcess.February2021.Presentation.Queries;
using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpGet("getcountries")]
        [ProducesResponseType(typeof(List<CountryResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<CountryResponse>>> Get()
        {
            try
            {
                var queries = new GetCountriesQuery();
                var result = await _mediator.Send(queries);

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError("getcountries > " + ex.Message);
                return BadRequest(ex.Message);

            }
        }
    }
}
