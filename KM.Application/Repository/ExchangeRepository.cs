using KM.Application.Dtos;
using KM.Infrastructure.GraphDB;
using KM.Infrastructure.GraphDB.Sparql;
using KM.Models.Exchange;
using Lucene.Net.Codecs;
using VDS.RDF;
using VDS.RDF.Dynamic;
using VDS.RDF.Query;
using VDS.RDF.Writing.Formatting;


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

    public async Task<IEnumerable<Exchange>> GetAll()
    {
        INodeFormatter formatter = new SparqlFormatter();
        var list = new List<Exchange>();

        var results = await _ctx.QueryAsync(ExchangeQueries.GetAll());
        var exchanges=results.AsDynamic();
        
            
        foreach (DynamicSparqlResult exchange in exchanges)
        {
            var dict=exchange.ToDictionary(k=>k.Key,v=>v.Value?.ToString());
            var ex = new Exchange(
                code: dict.GetValueOrDefault("code"),
                title: dict.GetValueOrDefault("title"),
                country: dict.GetValueOrDefault("country"),
                currency: dict.GetValueOrDefault("currency"),
                establishYear: int.TryParse(dict.GetValueOrDefault("establishYear"),out var establishYear)?establishYear:0,
                website:""
                );
            list.Add(ex);
        
        }


        return list;
    }
}