using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using vgr_platform_svc.Services;
using vgr_platform_svc.Models;
using vgr_platform_svc.Exceptions;

namespace vgr_platform_svc.Controllers
{
    [ApiController]
    [Route("platforms")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _service;

        public PlatformController(IPlatformService service)
        {
            _service = service;
        }

        // GET /platforms
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Platform>> ReadAll()
        {
            return Ok(_service.List());
        }

        // GET /platforms/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Platform> ReadByID(string id)
        {
            Platform platform;
            try
            {
                platform = _service.GetById(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return Ok(platform);
        }

        // POST /platforms
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Platform> Create([Bind("id,name")] Platform platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                platform = _service.Create(platform);
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Created("", platform);
        }

        // PUT /platforms/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Platform> Update(string id, [Bind("name")] UpdatePlatform updatePlatform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Platform platform = new(id, updatePlatform.Name);
            try
            {
                platform = _service.Update(platform);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ConflictException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok(platform);
        }

        // DELETE /platforms/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Platform> Delete(string id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NoContent();
        }
    }
}
