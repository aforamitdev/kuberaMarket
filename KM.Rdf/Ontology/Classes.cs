using VDS.RDF;

namespace KM.Rdf.Ontology;

public static class KmClasses
{
    public static IUriNode StockExchange(IGraph g)=>g.CreateUriNode(new Uri(KmNs.Base,"StockExcahnge"));
    
    public static IUriNode Country(IGraph g)=>g.CreateUriNode(new Uri(KmNs.Base,"Country"));

    public static IUriNode Currency(IGraph g)=>g.CreateUriNode(new Uri(KmNs.Base,"Currency"));

}