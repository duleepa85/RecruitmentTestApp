using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.BusinessLogic;
using Recruitment.Core.DomainObjects;

namespace Recruitment.API.Controllers
{
    [Produces("application/json")]
    [Route("api/JobApplication")]
    public class JobApplicationController : Controller
    {
        // GET: api/JobApplication
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RPApplication>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Get()
        {
          
            if (!ModelState.IsValid)
            {
                var msg = ModelState.Values.Select(P => P.Errors.Select(X => X.ErrorMessage + "," + X.Exception?.Message));
                return BadRequest(msg);
            }
            try
            {
                List<RPApplication> objlist = RecruitmentManager.GetAllApplications();
                return Ok(objlist);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                //return BadRequest(ex.Message);
                //return NotFound();
                //return NotFound();
                //return StatusCode(500);
                //return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "please try again later"));
            }
        }

        // GET: api/WFState
        [Route("GetStates")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WFState>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult GetStates()
        {

            if (!ModelState.IsValid)
            {
                var msg = ModelState.Values.Select(P => P.Errors.Select(X => X.ErrorMessage + "," + X.Exception?.Message));
                return BadRequest(msg);
            }
            try
            {
                List<WFState> objlist = RecruitmentManager.GetStates();
                return Ok(objlist);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Workflow
        [Route("GetWorkflows")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RPWorkflow>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult GetWorkflows()
        {

            if (!ModelState.IsValid)
            {
                var msg = ModelState.Values.Select(P => P.Errors.Select(X => X.ErrorMessage + "," + X.Exception?.Message));
                return BadRequest(msg);
            }
            try
            {
                List<RPWorkflow> objlist = RecruitmentManager.GetWorkflows();
                return Ok(objlist);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST: api/Status
        [Route("UpdateJobApplication")]
        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult UpdateJobApplication(RPApplication application)
        {
            try
            {
                var result = RecruitmentManager.UpdateJobApplication(application);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// GET: api/JobApplication/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/JobApplication
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/JobApplication/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
