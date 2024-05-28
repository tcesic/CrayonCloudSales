using AutoMapper;
using CrayonCloudSales.Repositories;
using CrayonCloudSales.ResponseRequestModels;
using CrayonCloudSales.Services.CcpService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CrayonCloudSales.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoftwaresController : ControllerBase
    {
        private readonly ISoftwareRepository _softwareRepository;
        private readonly IMapper _mapper;
        private readonly ICcpService _ccpService;

        public SoftwaresController(IMapper mapper, ISoftwareRepository softwareRepository, ICcpService ccpService)
        {
            _mapper = mapper;
            _softwareRepository = softwareRepository;
            _ccpService = ccpService;
        }

        [HttpGet("available")]
        public async Task<ActionResult<Service>> GetAvailableSoftwaresAsync()
        {
            var services = await _ccpService.GetAvailableServicesAsync();
            return Ok(services);
        }

        [HttpPost("order")]
        public async Task<ActionResult<SoftwareResponse>> OrderSoftware(SoftwareOrderRequest request)
        {
            var service = await _ccpService.OrderServiceAsync(request.ServiceId, request.Quantity);

            if (service == null)
            {
                return BadRequest("Service not available.");
            }

            var software = _mapper.Map<Software>((service, request, "active", DateTime.UtcNow.AddMonths(1)));

            await _softwareRepository.AddAsync(software);
            var softwareResponse = _mapper.Map<SoftwareResponse>(software);

            return CreatedAtAction(nameof(GetSoftware), new { id = software.Id }, softwareResponse);
        }

        [HttpPatch("{id}/quantity")]
        public async Task<IActionResult> ChangeQuantity(int id, [FromBody] int quantity)
        {
            var software = await _softwareRepository.GetByIdAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            software.Quantity = quantity;
            await _softwareRepository.UpdateAsync(software);

            return NoContent();
        }

        [HttpDelete("{id}/cancel")]
        public async Task<IActionResult> CancelSoftware(int id)
        {
            var software = await _softwareRepository.GetByIdAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            await _softwareRepository.DeleteAsync(software);

            return NoContent();
        }

        // Patch endpoint to extend the valid to date of a service by one month
        [HttpPatch("{id}/extend")]
        public async Task<IActionResult> ExtendValidity(int id)
        {
            var software = await _softwareRepository.GetByIdAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            software.ValidTo = software.ValidTo.AddMonths(1);
            await _softwareRepository.UpdateAsync(software);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SoftwareResponse>> GetSoftware(int id)
        {
            var software = await _softwareRepository.GetByIdAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            var softwareResponse = _mapper.Map<SoftwareResponse>(software);
            
            return Ok(softwareResponse);
        }


    }
}