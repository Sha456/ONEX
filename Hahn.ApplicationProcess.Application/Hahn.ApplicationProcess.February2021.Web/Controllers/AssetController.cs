using Hahn.ApplicationProcess.February2021.Presentation.Commands;
using Hahn.ApplicationProcess.February2021.Presentation.Queries;
using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(AssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AssetResponse>> Get(int assetid)
        {
            try
            {
                var queries = new GetAssetQuery(assetid);
                var result = await _mediator.Send(queries);
                _logger.LogInformation("Asset get > " + JsonSerializer.Serialize(result));

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError("Asset get > " + ex.Message);

                return BadRequest(ex.Message);

            }
        }



        [HttpPost("createasset")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateAsset([FromBody] CreateAssetCommand createAssetCommand)
        {
            try
            {
                var result = await _mediator.Send(createAssetCommand);
                _logger.LogInformation("Asset createasset > " + JsonSerializer.Serialize(result));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Asset createasset > " + ex.Message);

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editasset")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> EditAsset([FromBody] EditAssetCommand editAssetCommand)
        {
            try
            {
                var result = await _mediator.Send(editAssetCommand);
                _logger.LogInformation("Asset EditAsset > " + JsonSerializer.Serialize(result));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Asset editasset > " + ex.Message);

                return BadRequest(ex.Message);


            }

        }

        [HttpDelete("deleteasset")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteAsset([FromBody] DeleteAssetCommand deleteAssetCommand)
        {
            try
            {
                var result = await _mediator.Send(deleteAssetCommand);
                _logger.LogInformation("Asset deleteasset > " + JsonSerializer.Serialize(result));

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Asset deleteasset > " + ex.Message);

                return BadRequest(ex.Message);


            }

        }

        [HttpGet("getAllAssets")]
        [ProducesResponseType(typeof(List<AllAssetResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<AllAssetResponse>>> GetAssets()
        {
            try
            {
                var queries = new GetAllAssetsQuery();
                var result = await _mediator.Send(queries);

                _logger.LogInformation("Asset getAllAssets > " + JsonSerializer.Serialize(result));

                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError("Asset getAllAssets > " + ex.Message);

                return BadRequest(ex.Message);

            }
        }

    }
}
