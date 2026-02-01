namespace KM.Models.Exchange;

public record CreateExchangeRequest(string Code,string Title,string Country,string Currency,int EstablishYear,string website);