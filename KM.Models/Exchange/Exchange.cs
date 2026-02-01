
namespace KM.Models.Exchange;

public class Exchange
{
    public string Code { get; set; }
    public string Title { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
    public int  EstablishYear { get;init; }
    public string Website { get; set; }

    public Exchange(string code, string title, string currency, string country, int establishYear, string website)
    {
        Code = code;
        Title = title;
        Currency = currency;
        Country = country;
        EstablishYear = establishYear;
        Website = website;
        
    }

   
}