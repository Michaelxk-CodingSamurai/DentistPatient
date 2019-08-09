using Microsoft.AspNetCore.Mvc;
using System;

using Contracts;
using Entities.Models;

namespace DentistPatientServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public PatientController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDentists()
        {
            try
            {
                var patients = _repository.Patient.GetAllPatients();
                _logger.LogInfo($"Returned all patients from database");
                return Ok(patients);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPatients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientById(id);

                if (patient == null)
                {
                    _logger.LogError($"Patient with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned patient with id: {id}");
                    return Ok(patient);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error");

            }

        }

        [HttpGet("{id}/detail")]
        public IActionResult GetPatientWithDetails(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientWithDetails(id); 

                if (patient == null)
                {
                    _logger.LogError($"Patient with id: {id}, han't been found in db.");
                    return NotFound(); 
                }
                else
                {
                    _logger.LogInfo($"Returned patient with details for id: {id}");
                    return Ok(patient); 
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPatientWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error"); 

            }
        }


    }

}