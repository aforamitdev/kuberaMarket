using KM.Models.Graphs;
using KM.Models.Ontology;
using VDS.RDF.Query.Builder;

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

    public static string GetAll()
    {

        var query = QueryBuilder
            .Select("exchange", "code", "country", "currency", "establishedYear", "website");
            
            

                
       
        return $@"
                 PREFIX km:<{Km.Ns}>
                 PREFIX dc: <http://purl.org/dc/elements/1.1/>
                 SELECT ?exchange ?code  ?country ?currency ?establishedYear ?website
                 WHERE {{
                    GRAPH <{Graphs.Exchange}> {{
                        ?exchange a km:StockExchange; 
                        km:country ?country ;
                        km:code ?code ;
                        km:currency ?currency ;
                        km:establishedYear ?establishedYear ;
                        }}
                    }}
                ORDER BY ?code
                ";
    }

}