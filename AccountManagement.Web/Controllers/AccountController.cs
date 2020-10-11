using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain;
using AccountManagement.Domain.PrimaryPort;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IGetAccountsUseCase getAccountsUseCase;

        public AccountController(IGetAccountsUseCase getAccountsUseCase)
        {
            this.getAccountsUseCase = getAccountsUseCase;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var accounts = await getAccountsUseCase.GetAsync();

            var dtoAccounts = 
                accounts
                    .Select(a => AccountDto.FromDomain(a))
                    .ToList();
            
            return Ok(dtoAccounts);
        }
    }
}
