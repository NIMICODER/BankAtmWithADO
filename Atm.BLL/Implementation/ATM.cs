using Atm.DAL.Enums;

namespace AtmBLL.Implementation
{
    public class ATM
    {
        public string Name { get; set; }
        public decimal AvailableCash { get; set; }
        public Language CurrentLanguage { get; set; }
    }

    public class Account
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string AccountNo { get; set; }
        public AccountType AccountType { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }

    }
}
