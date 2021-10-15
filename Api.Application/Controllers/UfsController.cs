using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfsController: ControllerBase
    {
        public IUfService _service {get; set;}
       public UfsController(IUfService service)
       {
           _service = service;
       } 
       [Authorize("Bearer")]
       [HttpGet]
       public async Task<ActionResult> GetAll()
       {
           if(!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
           try {
               return Ok(await _service.GetAll());
           } catch(ArgumentException e)
           {
               return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
           }
       }

       [Authorize("Bearer")]
       [HttpGet]
       [Route("{id}")]
       public async Task<ActionResult> Get(Guid id)
       {
           if(!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
           try 
           {
               return Ok(await _service.Get(id));
           } catch(ArgumentException e) 
           {
               return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
           }
       }
    }
}
