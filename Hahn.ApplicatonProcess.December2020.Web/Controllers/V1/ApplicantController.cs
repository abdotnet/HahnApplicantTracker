using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicantService;
using Hahn.ApplicatonProcess.December2020.Web.Contracts.V1.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicantService"></param>
        /// <param name="mapper"></param>
        public ApplicantController(IApplicantService applicantService, Mapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }

        /// <summary>
        /// Post applicant information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicantRequest model)
        {

             var applicant = _mapper.Map<Applicant>(model);
          
            var response = await _applicantService.CreateApplicant(applicant);


            return Created(response.Message, response);
        }

        /// <summary>
        /// Get applicant information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchModel model)
        {

            var response = await _applicantService.GetApplicant(model);

            return Ok(response);
        }
        /// <summary>
        /// Update applicant information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ApplicantRequest model)
        {
            var applicant = _mapper.Map<Applicant>(model);

            var response = await _applicantService.UpdateApplicant(applicant);

            return Ok(response);
        }

        /// <summary>
        /// Delete applicant information
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _applicantService.DeleteApplicant(id);

            return Ok(response);
        }
    }
}
