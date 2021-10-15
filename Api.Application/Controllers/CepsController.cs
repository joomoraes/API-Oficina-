using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.CEP;
using Api.Domain.Dtos.Municipios;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepsController: ControllerBase
    {
        public ICepService _service {get; set;}
        public CepsController(ICepService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCepWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                var result = await _service.Get(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("byCep/{cep}")]
        public async Task<ActionResult> Get(string cep)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                var result = await _service.Get(cep);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CepDtoCreate dtoCreate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(dtoCreate);
                if(result != null)
                {
                    return Created(new Uri(Url.Link("GetCepWithId", new {id = result.Id})), result);
                } else {
                    return BadRequest();
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Put([FromBody] CepDtoUpdate dtoUpdate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                var result = await _service.Put(dtoUpdate);
                if(result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
