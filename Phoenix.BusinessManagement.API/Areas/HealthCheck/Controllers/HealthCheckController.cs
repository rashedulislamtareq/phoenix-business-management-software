using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.BusinessManagement.ClientModel.Helper;
using Phoenix.BusinessManagement.ClientModel.Models.HealthCheck;
using Phoenix.BusinessManagement.ClientModel.Validator.HealthCheck;
using Phoenix.BusinessManagement.Entity.Domain.HealthCheck;
using Phoenix.BusinessManagement.Entity.Utility;
using Phoenix.BusinessManagement.Service.Services;
using static Phoenix.BusinessManagement.Entity.Utility.AppConstants;

namespace Phoenix.BusinessManagement.API.Areas.HealthCheck.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int _loggedInUserId = 1;

        public HealthCheckController(IHealthCheckService healthCheckService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _healthCheckService = healthCheckService;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int size = 10, byte statusId = (byte)StatusId.Active)
        {
            try
            {
                var request = _httpContextAccessor.HttpContext.Request;
                var result = await _healthCheckService.GetAll(page, size, statusId, request);

                if (result != null || result.TotalElements > 0)
                    return Ok(result);

                var msg = Utilities.GetNoDataFoundMsg();
                return StatusCode((int)msg.StatusCode, msg);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utilities.GetInternalServerErrorMsg(ex));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _healthCheckService.GetById(id);
                if (result != null)
                    return Ok(result);

                var msg = Utilities.GetNoDataFoundMsg();
                return StatusCode((int)msg.StatusCode, msg);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utilities.GetInternalServerErrorMsg(ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HealthCheckCreateVM model)
        {
            try
            {
                var validationResult = await new HealthCheckCreateValidator().ValidateAsync(model);
                if (validationResult.IsValid)
                {
                    var result = await _healthCheckService.Create(model, _loggedInUserId);
                    return Ok(result);
                }
                else
                {
                    var result = Utilities.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
                    return StatusCode((int)result.StatusCode, result);
                }
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utilities.GetInternalServerErrorMsg(ex));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HealthCheckUpdateVM model)
        {
            try
            {
                var validationResult = await new HealthCheckUpdateValidator(id).ValidateAsync(model);
                if (validationResult.IsValid)
                {
                    var result = await _healthCheckService.Update(model, _loggedInUserId);
                    return Ok(result);
                }
                else
                {
                    var result = Utilities.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
                    return StatusCode((int)result.StatusCode, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utilities.GetInternalServerErrorMsg(ex));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _healthCheckService.ModifyStatus(id, (byte)StatusId.Delete, _loggedInUserId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utilities.GetInternalServerErrorMsg(ex));
            }
        }

        [HttpGet("DoHealthCheck")]
        public IActionResult DoHealthCheck()
        {
            return Ok(new Application()
            {
                Id = 1,
                Name = _configuration.GetSection("Application:Name").Value,
                Description = _configuration.GetSection("Application:Description").Value,
                Version = _configuration.GetSection("Application:Version").Value
            });

        }
    }
}
