using VDS.RDF;

namespace KM.Ontology;

public class RelationShip
{
    public static IGraph Create()
    {
        var g = new Graph()
        {
            BaseUri = new Uri("http://kuber.finance/ontology/relationship")
        };
        NamespaceHelper.AddCommonNamespaces(g);
        
        var rdfType=g.CreateUriNode("rdf:type");
        
        var prop=g.CreateUriNode("rdf:property");
        
        g.Assert(prop, rdfType, g.CreateUriNode("owl:ObjectProperty"));
        g.Assert(prop, g.CreateUriNode("rdfs:domain"), g.CreateUriNode("km:Company"));
        g.Assert(prop, g.CreateUriNode("rdfs:range"), g.CreateUriNode("km:Exchange"));

        return g;
        
    }
}