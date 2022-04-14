using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TokaDomain.DTO;
using TokaService.Interfaces;

namespace TokaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaFisicaController : ControllerBase
    {
        private readonly IPersonaFisicaService _personaFisicaService;

        public PersonaFisicaController(IPersonaFisicaService personaFisicaService)
        {
            this._personaFisicaService = personaFisicaService ?? throw new ArgumentException(nameof(personaFisicaService));
        }

        [HttpGet()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ObtenerPersonasFisicas()
        {
            try
            {
                var respuesta = _personaFisicaService.ObtenerPersonasFisicas();

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }

        }

        [HttpPost()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult CrearPersonaFisica([FromBody] PersonaFisica modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var respuesta = _personaFisicaService.RegistrarPersonaFisica(modelo);
                    if (respuesta.Estatus)
                    {
                        return Created("", respuesta);
                    }
                    else
                    {
                        return Conflict(respuesta);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }

        }

        [HttpPut()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ModificarPersonaFisica([FromBody] ModificarPersonaFisica modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var respuesta = _personaFisicaService.ModificarPersonaFisica(modelo);
                    if (respuesta.Estatus)
                    {
                        return Ok(respuesta);
                    }
                    else
                    {
                        return Conflict(respuesta);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }

        }

        [HttpDelete()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult EliminarPersonaFisica(int idPersonaFisica)
        {
            try
            {
                var respuesta = _personaFisicaService.EliminarPersonaFisica(idPersonaFisica);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }

        }
    }
}
