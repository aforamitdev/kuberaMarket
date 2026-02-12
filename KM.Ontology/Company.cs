using VDS.RDF;

namespace KM.Ontology;

public static class Company
{
    public static IGraph Create()
    {
        var g = new Graph
        {
            BaseUri = new Uri("http://kuber.finance/ontology/company")
        };
        NamespaceHelper.AddCommonNamespaces(g);

        var rdfType = g.CreateUriNode("rdf:type");
        var owlClass=g.CreateUriNode("owl:Class");
        var owlDatatypeProperty = g.CreateUriNode("owl:DatatypeProperty");
        
        var company = g.CreateUriNode("km:Company");
        g.Assert(company, rdfType, owlClass);
        CreateDatatypeProperty(g, "value", "Company", "decimal");
        CreateDatatypeProperty(g, "code", "Company", "string");
        return g;
    }

    private static void CreateDatatypeProperty(IGraph g,string name, string domain, string xsdType)
    {
        var rdfType=g.CreateUriNode("rdf:type");
        var prop = g.CreateUriNode($"km:{domain}");
        
        g.Assert(prop,rdfType,g.CreateUriNode("owl:DatatypeProperty"));
        g.Assert(prop,g.CreateUriNode("rdfs:domain"), g.CreateUriNode($"km:{domain}"));
        g.Assert(prop, g.CreateUriNode("rdfs:range"), g.CreateUriNode($"xsd:{xsdType}"));

    }
}