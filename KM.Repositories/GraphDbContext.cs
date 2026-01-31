using System.Text;
using Microsoft.Extensions.Configuration;

namespace KM.Repositories;

public class GraphDbContext:IGraphDbContext
{
    
    private readonly HttpClient _httpClient;
    private readonly string _queryEndpoint;
    private readonly string _updateEndpoint;

    public GraphDbContext(HttpClient httpClient,IConfiguration configuration)
    {
        _httpClient = httpClient;
        
        var baseUrl=configuration["GraphDB:BaseUrl"];
        var repo=configuration["GraphDB:Repository"];
        
        _queryEndpoint  = $"{baseUrl}/repositories/{repo}";
        _updateEndpoint = $"{baseUrl}/repositories/{repo}/statements";

        
    }


    public async  Task<string> QueryAsync(string sparsql)
    {

        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("sparsql", sparsql)
        });
        var response=await  _httpClient.PostAsync(_queryEndpoint, content);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task ExecuteAsync(string sparql)
    {
        var content=new StringContent(sparql,Encoding.UTF8,"application/sparql-update");
        var response = await _httpClient.PostAsync(_updateEndpoint, content);
        response.EnsureSuccessStatusCode();       
    }
}