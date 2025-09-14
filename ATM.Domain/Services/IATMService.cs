using ATM.Domain.Models;

namespace ATM.Domain.Services
{
    public interface IATMService
    {
        /// <summary>
        /// Get a list of accounts
        /// </summary>
        /// <returns>a list of <see cref="Account"/></returns>
        IList<Account> GetAccounts();

        /// <summary>
        /// Gets a list of the 10 most recent transactions
        /// </summary>
        /// <returns> a list of <see cref="Transaction"/></returns>
        IList<Transaction> GetRecentTransactions();

        /// <summary>
        /// Processes the requested <see cref="Transaction"/> and returns the list of effected <see cref="Account"/>
        /// </summary>
        /// <typeparam name="T"><see cref="Transaction"/> type</typeparam>
        /// <param name="transaction"> new <see cref="Transaction"/> to process</param>
        /// <returns>a list of <see cref="Account"/></returns>
        /// <exception cref="InvalidTransactionException"></exception>
        IList<Account> ProcessAccountTransaction<T>(T transaction) where T : Transaction;
    }
}