namespace KM.Repositories;

public interface IGraphDbContext
{
    Task<string> QueryAsync(string sparsql);
    Task ExecuteAsync(string sparql);
}