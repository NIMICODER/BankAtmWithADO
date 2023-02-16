namespace Atm.BLL.Interfaces
{
    public interface IAtmService
    {
        void Start();
        void Withdraw();
        void CheckBalance();
        void Transfer();
        void Deposit();
        void PayBill();
        void CreateAccount();
        void ReloadCash();
    }
}
