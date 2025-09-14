using ATM.Domain.Exceptions;
using ATM.Domain.Models;
using ATM.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly ILogger<ATMController> _logger;
        private readonly IATMService _transactionService;

        public ATMController(ILogger<ATMController> logger, IATMService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        /// <summary>
        /// Get a list of active accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet("accounts")]
        public IActionResult GetAccounts()
        {
            try
            {
                return Ok(_transactionService.GetAccounts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a 10 most recent transactions in history
        /// </summary>
        /// <returns></returns>
        [HttpGet("history")]
        public IActionResult  GetHistory()
        {
            try
            {
                return Ok(_transactionService.GetRecentTransactions());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Process Deposit transactions
        /// </summary>
        /// <returns></returns>
        [HttpPost("deposit")]
        public IActionResult ProcessTransaction([FromBody] Deposit transaction)
        {
            try
            {
                return Ok(_transactionService.ProcessAccountTransaction(transaction));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Process Withdrawal transactions
        /// </summary>
        /// <returns></returns>
        [HttpPost("withdrawal")]
        public IActionResult ProcessTransaction([FromBody] Withdrawal transaction)
        {
            try
            {
                return Ok(_transactionService.ProcessAccountTransaction(transaction));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Process Withdrawal transactions
        /// </summary>
        /// <returns></returns>
        [HttpPost("transfer")]
        public IActionResult ProcessTransaction([FromBody] Transfer transaction)
        {
            try
            {
                return Ok(_transactionService.ProcessAccountTransaction(transaction));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
