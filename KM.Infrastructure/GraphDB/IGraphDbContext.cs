namespace KM.Infrastructure.GraphDB;
using VDS.RDF.Query;

public interface IGraphDbContext
{
    Task ExecuteUpdateAsync(string sparql);
    Task<SparqlResultSet> QueryAsync(string sparql);
}