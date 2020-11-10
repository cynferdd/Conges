using System;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain;
using AccountManagement.Domain.PrimaryPort;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Exceptions;

namespace AccountManagement.Web.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IGetAccountsUseCase getAccountsUseCase;
        private readonly IArchiveAccountUseCase archiveAccountUseCase;
        private readonly ICreateAccountUseCase createAccountUseCase;

        public AccountController(IGetAccountsUseCase getAccountsUseCase, IArchiveAccountUseCase archiveAccountUseCase, ICreateAccountUseCase createAccountUseCase)
        {
            this.getAccountsUseCase = getAccountsUseCase;
            this.archiveAccountUseCase = archiveAccountUseCase;
            this.createAccountUseCase = createAccountUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                var account = await this.getAccountsUseCase.GetAsync(new AccountId(id));

                var dtoAccount = AccountDto.FromDomain(account);

                return Ok(dtoAccount);
            }
            catch (NotFoundException<AccountId>)
            {
                return NotFound();
            }
            
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
        public async Task<IActionResult> ArchiveAsync([FromRoute]int id)
        {
            try
            {
                await this.archiveAccountUseCase.ArchiveAsync(new AccountId(id));
                return Ok();
            }
            catch (NotFoundException<AccountId>)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]AccountDto accountToCreate)
        {
            try
            {
                await this.createAccountUseCase.CreateAsync(accountToCreate.ToDomain());
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }
    }
}
