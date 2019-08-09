using Microsoft.AspNetCore.Mvc;
using System;

using Contracts;
using Entities.Models;
using Entities.Extensions;

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

        [HttpGet("{id}", Name = "PatientById")]
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

        [HttpPost]
        public IActionResult CreatePatient([FromBody]Patient patient)
        {
            try
            {
                if (patient.IsObjectNull())
                {
                    _logger.LogError("Patient object sent from client is null.");
                    return BadRequest("Patient Object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Patient object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Patient.CreatePatient(patient);

                return CreatedAtRoute("PatientById", new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePatient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody]Patient Patient)
        {
            try
            {
                if (Patient.IsObjectNull())
                {
                    _logger.LogError("Patient object sent from client is null.");
                    return BadRequest("Patient object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Patient object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbPatient = _repository.Patient.GetPatientById(id);

                if (dbPatient.IsEmptyObject())
                {
                    _logger.LogError($"Patient with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Patient.UpdatePatient(dbPatient, Patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePatient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                var patient = _repository.Patient.GetPatientById(id);
                if (patient.IsEmptyObject())
                {
                    _logger.LogError($"Patient with id: {id}, has't been foound in db.");
                    return NotFound();
                }


                _repository.Patient.DeletePatient(patient);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePatient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}