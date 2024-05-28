using AutoMapper;
using CrayonCloudSales.Repositories;
using CrayonCloudSales.ResponseRequestModels;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;


namespace CrayonCloudSales.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ISoftwareRepository _softwareRepository;
        private readonly IMapper _mapper;

        public AccountsController(IMapper mapper, IAccountRepository accountRepository, ISoftwareRepository softwareRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _softwareRepository = softwareRepository;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAccountsByCustomer(int customerId)
        {
            var accounts = await _accountRepository.GetAccountsByCustomerAsync(customerId);
            var accountsResponses = _mapper.Map<IEnumerable<AccountResponse>>(accounts);
            return Ok(accountsResponses);
        }

        [HttpGet("{id}/softwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetAccountSoftwares(int id)
        {
            var softwares = await _softwareRepository.GetAccountSoftwaresAsync(id);
            var softwareResponses = _mapper.Map<IEnumerable<SoftwareResponse>>(softwares);
            return Ok(softwareResponses);
        }
    }
}