using KM.Models.Exchange;
using KM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KuberaMarket.Controllers;


[ApiController]
[Route("api/exchange")]
public class ExchangeController
{
    public ExchangeController(IGraphDbContext db)
    {
        
    }

    [HttpGet]
    public List<Exchange> GetExchange()
    {
        var exchanges = new List<Exchange>{new Exchange
        {
            Code = "BAS",
            Country = "India",
            Currency = "INR",
            Title = "Main",
            Website = "www.excga.res",
            EstablishYear = 2133
        }};


        return exchanges.ToList();
    }
}