using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

using Contracts;
using Entities.Models;
using Entities.Extensions;

namespace DentistPatientServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DentistController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public DentistController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDentists()
        {
            try
            {
                var dentists = _repository.Dentist.GetAllDentists();
                _logger.LogInfo($"Returned all dentists from database");
                return Ok(dentists);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDentists action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "DentistById")]
        public IActionResult GetDentistById(int id)
        {
            try
            {
                var dentist = _repository.Dentist.GetDentistById(id);

                if (dentist.IsEmptyObject())
                {
                    _logger.LogError($"Dentist with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned dentist with id: {id}");
                    return Ok(dentist);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDentistById action: {ex.Message}");
                return StatusCode(500, "Internal server error");

            }

        }

        [HttpGet("{id}/detail")]
        public IActionResult GetDentistWithDetails(int id)
        {
            try
            {
                var dentist = _repository.Dentist.GetDentistWithDetails(id);

                if (dentist.IsEmptyObject())
                {
                    _logger.LogError($"Dentist with id: {id}, han't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned dentist with details for id: {id}");
                    return Ok(dentist);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDentistWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpPost]
        public IActionResult CreateDentist([FromBody]Dentist dentist)
        {
            try
            {
                if (dentist.IsObjectNull())
                {
                    _logger.LogError("Dentist object sent from client is null.");
                    return BadRequest("Dentist Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid dentist object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Dentist.CreateDentist(dentist);

                return CreatedAtRoute("DentistById", new { id = dentist.Id }, dentist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDentist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDentist(int id, [FromBody]Dentist dentist)
        {
            try
            {
                if (dentist.IsObjectNull())
                {
                    _logger.LogError("dentist object sent from client is null.");
                    return BadRequest("dentist object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid dentist object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbDentist = _repository.Dentist.GetDentistById(id);

                if (dbDentist.IsEmptyObject())
                {
                    _logger.LogError($"Dentist with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Dentist.UpdateDentist(dbDentist, dentist);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDentist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDentist(int id)
        {
            try
            {
                var dentist = _repository.Dentist.GetDentistById(id);
                if (dentist.IsEmptyObject())
                {
                    _logger.LogError($"Dentist with id: {id}, has't been foound in db.");
                    return NotFound();
                }

                if(_repository.Patient.PatientsByDentist(id).Any())
                {
                    _logger.LogError($"Cannot delete dentist with id: {id}. It has related patients. Delete those patients first");
                    return BadRequest("Cannot delete dentist. It has related patients. Delete those patients first");
                }

                _repository.Dentist.DeleteDentist(dentist);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteDentist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}