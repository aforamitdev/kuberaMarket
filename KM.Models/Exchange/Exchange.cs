using System.Reflection.Emit;

namespace KM.Models.Exchange;

public class Exchange
{
    public string Code { get; set; }
    public string Title { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
    public int  EstablishYear { get;init; }
    public string Website { get; set; }
}