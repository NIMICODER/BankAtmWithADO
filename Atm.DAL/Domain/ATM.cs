using Atm.DAL.Enums;

namespace AtmBLL.Implementation
{
    public class ATM
    {
        public string Name { get; set; }
        public decimal AvailableCash { get; set; }
        public Language CurrentLanguage { get; set; }
    }
}
