using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Services;
using Hahn.ApplicatonProcess.December2020.Domain.Contracts.V1.Requests;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Infrastructure;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService;
using Hahn.ApplicatonProcess.December2020.Web.Helpers;
using Hahn.ApplicatonProcess.December2020.Web.Helpers.Swagger;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicantService"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ApplicantController(IApplicantService applicantService, IMapper mapper,
           IUnitOfWork unitOfWork)
        {
            _applicantService = applicantService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Post applicant information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(ApplicantRequest), typeof(ApplicantRequestExample))]
        public async Task<IActionResult> Post([FromBody] ApplicantRequest model)
        {
            var applicant = _mapper.Map<Applicant>(model);

            _unitOfWork.Applicant.Add(applicant);
            int success = await _unitOfWork.Complete();

            if (success > 0)
            {
                string appUrl = $"{Urls.GetUrl(HttpContext)}{applicant.ID}";

                var apiReponse = new ApiResponse()
                {
                    Status = ApplicationStatusCode.Successful,
                    Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.Successful),
                    Data = new { url = appUrl }
                };
                return Created(appUrl, apiReponse);
            }

            var response = JsonConvert.SerializeObject(new ApiResponse() { Status = ApplicationStatusCode.BadRequest, Message = "BadRequest" });

            return BadRequest(response);
        }

        /// <summary>
        /// Get applicant information
        /// </summary>
        /// <returns></returns>
        [HttpGet("{applicantId}")]
        public async Task<IActionResult> Get(int applicantId)
        {
            var applicant = await _unitOfWork.Applicant.Get(applicantId);

            if (applicant == null)
            {
                var reponse = new ApiResponse()
                {
                    Status = ApplicationStatusCode.NotFound,
                    Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.NotFound),
                    Data = "Not Found"
                };
                return NotFound(reponse);
            }

            var apiReponse = new ApiResponse()
            {
                Status = ApplicationStatusCode.Successful,
                Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.Successful),
                Data = applicant
            };

            return Ok(apiReponse);
        }

        /// <summary>
        /// Update applicant information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ApplicantUpdateRequest model)
        {
            var applicantMap = _mapper.Map<Applicant>(model);

            var appResponse = await _unitOfWork.Applicant.Get(applicantMap.ID);

            if (appResponse == null)
            {
                var reponse = new ApiResponse()
                {
                    Status = ApplicationStatusCode.NotFound,
                    Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.NotFound),
                    Data = "Not Found"
                };
                return NotFound(reponse);
            }

            var applicant = _mapper.Map<Applicant>(appResponse);
            _unitOfWork.Applicant.Update(applicant);
            var response = await _unitOfWork.Complete();

            var apiReponse = new ApiResponse()
            {
                Status = ApplicationStatusCode.Successful,
                Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.Successful),
                Data = "Updated"
            };
            return Ok(apiReponse);
        }

        /// <summary>
        /// Delete applicant information
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var applicant = await _unitOfWork.Applicant.Get(id);
            if (applicant == null)
            {
                var reponse = new ApiResponse()
                {
                    Status = ApplicationStatusCode.NotFound,
                    Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.NotFound),
                    Data = "Not Found"
                };
                return NotFound(reponse);
            }

            _unitOfWork.Applicant.Remove(applicant);
            await _unitOfWork.Complete();

            var apiReponse = new ApiResponse()
            {
                Status = ApplicationStatusCode.Successful,
                Message = ApplicationStatusCode.GetResponseCode(ApplicationStatusCode.Successful),
                Data = "Deleted"
            };
            return Ok(apiReponse);
        }
    }
}
