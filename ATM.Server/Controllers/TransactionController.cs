using ATM.Domain.Exceptions;
using ATM.Domain.Models;
using ATM.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
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
