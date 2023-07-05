using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models;

public class TransactionModel
{
    public int? Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Value { get; set; }
    public string History { get; set; }
    public int AccountId { get; set; }

    public AccountModel ItemAccount { get; set; }
    public IEnumerable<SelectListItem>? Accounts { get; set; }
}

