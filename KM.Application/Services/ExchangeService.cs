using KM.Application.Dtos;
using KM.Application.Repository;
using KM.Models.Exchange;

namespace KM.Application.Services;

public class ExchangeService:IExchangeService
{
    private readonly IExchangeRepository  _exchangeRepo;

    public ExchangeService(IExchangeRepository exchangeRepo)
    {
        _exchangeRepo = exchangeRepo;
    }

    public Task Create(CreateExchangeDto exchange)
    {   
        Exchange newExchange=new Exchange(exchange.Code,exchange.Title,exchange.Currency,exchange.Country,exchange.EstablishedYear,"weee.sb.com");
        return  _exchangeRepo.Create(newExchange);
    }

    public Task<IEnumerable<Exchange>> GetExchange()
    {
        return _exchangeRepo.GetAll();
    }


}