using KM.Models.Graphs;
using KM.Models.Ontology;

namespace KM.Infrastructure.GraphDB.Sparql;

public static class ExchangeQueries
{
    public static string Insert(string code,
        string title,
        string country,
        string currency,
        int establishedYear,
        string website)
    {

        var data= $@"
                  PREFIX km:<{Km.Ns}>
                  PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                  
                  INSERT DATA {{
                     GRAPH <{Graphs.Exchange}> {{
                       <http://kuber.finance/exchange/{code}>
                         a <{Km.Classes.StockExchange}> ;
                         dc:title ""{title}"" ;
                         km:code ""{code}"" ;
                         km:country ""{country}"" ;
                         km:currency ""{currency}"" ;
                         km:establishedYear ""{establishedYear}""^^xsd:gYear .
                           
                     }}
                   }}           
                  ";
        Console.Write(data);
        return data;
    }
}