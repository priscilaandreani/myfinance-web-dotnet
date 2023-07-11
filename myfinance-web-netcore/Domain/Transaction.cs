
namespace myfinance_web_netcore.Domain
{
    public class Transaction
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string History { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }

}

