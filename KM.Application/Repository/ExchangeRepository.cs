using KM.Application.Dtos;
using KM.Infrastructure.GraphDB;
using KM.Infrastructure.GraphDB.Sparql;
using KM.Models.Exchange;


namespace KM.Application.Repository;

public class ExchangeRepository:IExchangeRepository
{
    
    private readonly IGraphDbContext _ctx;

    public ExchangeRepository(IGraphDbContext ctx)
    {
        _ctx = ctx;
        
    }
        
    public Task Create(Exchange exchange)
    {
      
        return _ctx.ExecuteUpdateAsync(ExchangeQueries.Insert(exchange.Code,exchange.Title,exchange.Country,exchange.Currency,exchange.EstablishYear,"wee.data.data"));
    }

  
}