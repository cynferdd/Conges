using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain;
using AccountManagement.Domain.PrimaryPort;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Core.Exceptions;

namespace AccountManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IGetAccountsUseCase getAccountsUseCase;
        private readonly IArchiveAccountUseCase archiveAccountUseCase;

        public AccountController(IGetAccountsUseCase getAccountsUseCase, IArchiveAccountUseCase archiveAccountUseCase)
        {
            this.getAccountsUseCase = getAccountsUseCase;
            this.archiveAccountUseCase = archiveAccountUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromQuery] int id)
        {
            var account = await this.getAccountsUseCase.GetAsync(id);

            var dtoAccount = AccountDto.FromDomain(account);

            return Ok(dtoAccount);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var accounts = await this.getAccountsUseCase.GetAsync();

            var dtoAccounts = 
                accounts
                    .Select(a => AccountDto.FromDomain(a))
                    .ToList();
            
            return Ok(dtoAccounts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ArchiveAsync([FromQuery]int id)
        {
            try
            {
                await this.archiveAccountUseCase.ArchiveAsync(id);
                return Ok();
            }
            catch (NotFoundException<int>)
            {
                return NotFound();
            }
            
        }
    }
}
