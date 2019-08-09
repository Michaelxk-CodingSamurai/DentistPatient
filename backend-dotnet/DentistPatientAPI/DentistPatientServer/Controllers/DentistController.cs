using Microsoft.AspNetCore.Mvc;
using System;

using Contracts;
using Entities.Models; 

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

        [HttpGet("{id}")]
        public IActionResult GetDentistById(int id)
        {
            try
            {
                var dentist = _repository.Dentist.GetDentistById(id);

                if (dentist == null)
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

                if (dentist == null)
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
    }
}