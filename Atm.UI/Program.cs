using Atm.BLL.Implementation;
using Atm.DAL.Database;
using Atm.DAL.Enums;

namespace Atm.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bank = new BankAppDB();
            bank.CreateDatabase();
            bank.CreateTable();
            AtmAppMenu.MainMenuChoice();
        }
    }
}