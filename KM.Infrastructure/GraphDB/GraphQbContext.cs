using System.Net;
using Microsoft.Extensions.Configuration;
using VDS.RDF.Query;
using VDS.RDF.Update;

namespace KM.Infrastructure.GraphDB;

public class GraphDbContext : IGraphDbContext
{
    private readonly SparqlRemoteEndpoint _query;
    private readonly SparqlRemoteUpdateEndpoint _update;

    public GraphDbContext(HttpClient http, IConfiguration cfg)
    {
        var baseUrl = cfg["GraphDB:BaseUrl"];
        var repo = "kubera-finance";

        _query = new SparqlRemoteEndpoint(
            new Uri($"{baseUrl}/repositories/{repo}")
        );
        _query.HttpMode = "POST";
        
        _update = new SparqlRemoteUpdateEndpoint(
            new Uri($"{baseUrl}/repositories/{repo}/statements")
        );

    }

    public Task ExecuteUpdateAsync(string sparql)
    {
        try
        {
        
            _update.Update(sparql);
            return Task.CompletedTask;
        }
        catch (WebException ex)
        {
            using var stream = ex.Response.GetResponseStream();
            using var reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
            
            Console.WriteLine(ex);
            throw;
        }
    }

    public Task<SparqlResultSet> QueryAsync(string sparql)
    {
        try
        {
            Console.WriteLine(sparql);
       
            var result = _query.QueryWithResultSet(sparql);
            
            return Task.FromResult(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
}