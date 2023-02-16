namespace Atm.BLL.Interfaces
{
    public interface IAtmService
    {
        void Start();
        //void Withdraw(decimal amount);
        //void CheckBalance(AccountType accountType);
        // void Transfer(string accountNo, Bank bank, decimal amount);
        //void Deposit(string accountNo, AccountType accountType, decimal amount);
        void PayBill();
        void CreateAccount();
        void ReloadCash();
    }
}
