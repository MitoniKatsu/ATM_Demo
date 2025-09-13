namespace ATM.Domain.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
        public double Balance { get; set; }
    }
}
