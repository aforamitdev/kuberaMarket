using VDS.RDF;

namespace KM.Ontology;

public static class Exchange
{
    public static IGraph Create()
    {
        var g = new Graph
        {
            BaseUri = new Uri("http://kuber.finance/ontology/exchange")
        };


        NamespaceHelper.AddCommonNamespaces(g);

        var rdfType = g.CreateUriNode("rdf:type");
        var owlClass = g.CreateUriNode("owl:Class");

        var exchange = g.CreateUriNode("km:Exchange");
        g.Assert(exchange, rdfType, owlClass);

        CreateDatatypeProperty(g, "title", "Exchange", "string");
        CreateDatatypeProperty(g, "website", "Exchange", "anyURI");
        CreateDatatypeProperty(g, "totalValue", "Exchange", "decimal");

        return g;
    }
    
    private static void CreateDatatypeProperty(IGraph g, string name, string domain, string xsdType)
    {
        var rdfType = g.CreateUriNode("rdf:type");
        var prop = g.CreateUriNode($"km:{name}");

        g.Assert(prop, rdfType, g.CreateUriNode("owl:DatatypeProperty"));
        g.Assert(prop, g.CreateUriNode("rdfs:domain"), g.CreateUriNode($"km:{domain}"));
        g.Assert(prop, g.CreateUriNode("rdfs:range"), g.CreateUriNode($"xsd:{xsdType}"));
    }
    
}