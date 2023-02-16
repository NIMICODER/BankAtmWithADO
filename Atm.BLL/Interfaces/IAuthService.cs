namespace Atm.BLL.Interfaces
{
    public interface IAuthService
    {
        void Login();

        void ResetPin();

        void LogOut();
    }
}
