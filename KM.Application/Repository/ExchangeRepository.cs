using KM.Application.Dtos;
using KM.Infrastructure.GraphDB;
using KM.Infrastructure.GraphDB.Sparql;
using KM.Models.Exchange;
using Lucene.Net.Codecs;
using VDS.RDF;
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
        
        var results = await _ctx.QueryAsync(ExchangeQueries.GetAll());
        foreach (SparqlResult result in results)
        {
            Console.Write(result.ToString(formatter)+"TESTTT");
        }
        var exchange=results.Select(r =>
        {
            var a = r["code"];
            
            return new Exchange(code: r["code"]!.ToString(), title: "", r["country"]!.ToString(), "", 12, "");
        });
        return exchange;
    }
}