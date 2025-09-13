using ATM.Domain.Exceptions;
using ATM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private static readonly IList<Transaction> _transactionHistory = new List<Transaction>();
        private static IList<Account> _accounts = new List<Account>
        {
            //dummy acounts for demonstration purposes
            new()
            {
                AccountHolder = "Test Testerson",
                AccountName = "Checking",
                AccountNumber = 12345,
                Balance = 1000.21
            },
            new()
            {
                AccountHolder = "Test Testerson",
                AccountName = "Savings",
                AccountNumber = 54321,
                Balance = 5000
            }
        };

        /// <summary>
        /// <see cref="ITransactionService.ProcessAccountTransaction{T}(T)"/>
        /// </summary>
        public IList<Account> ProcessAccountTransaction<T>(T transaction) where T : Transaction
        {
            IList<Account> transactionAccounts = new List<Account>();

            Account account = _accounts.FirstOrDefault(o => o.AccountNumber == transaction.AccountNumber) ?? throw new InvalidTransactionException("Account not found");

            switch (transaction.TransactionType)
            {
                case TransactionType.DEPOSIT:
                    account.Balance += transaction.Amount;
                    transactionAccounts.Add(account);
                    break;
                case TransactionType.WITHDRAWAL:
                    if (account.Balance < transaction.Amount)
                        throw new InvalidTransactionException("Account has insufficient funds to process this transaction");

                    account.Balance -= transaction.Amount;
                    transactionAccounts.Add(account);
                    break;
                case TransactionType.TRANSFER:
                    Account targetAccount = _accounts.FirstOrDefault(o => o.AccountNumber == transaction.TargetAccountNumber) ?? throw new InvalidTransactionException("Target Account not found");
                    if (account.Balance < transaction.Amount)
                        throw new InvalidTransactionException("Account has insufficient funds to process this transaction");
                    account.Balance -= transaction.Amount;
                    targetAccount.Balance += transaction.Amount;
                    transactionAccounts.Add(account);
                    transactionAccounts.Add(targetAccount);
                    break;
            }

            _transactionHistory.Add(transaction);

            return transactionAccounts;
        }

        /// <summary>
        /// <see cref="ITransactionService.GetRecentTransactions"/>
        /// </summary>
        public IList<Transaction> GetRecentTransactions()
        {
            return _transactionHistory.OrderByDescending(o => o.TransactionTime).Take(10).ToList();
        }

    }
}
