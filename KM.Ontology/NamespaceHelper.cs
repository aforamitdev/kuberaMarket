using VDS.RDF;
using VDS.RDF.Parsing;

namespace KM.Ontology;

public static class NamespaceHelper
{
    public static void AddCommonNamespaces(IGraph g)
    {
        g.NamespaceMap.AddNamespace("km", new Uri("http://kuber.finance/ontology/"));
        g.NamespaceMap.AddNamespace("rdf", new Uri(NamespaceMapper.RDF));
        g.NamespaceMap.AddNamespace("rdfs", new Uri(NamespaceMapper.RDFS));
        g.NamespaceMap.AddNamespace("owl", new Uri(NamespaceMapper.OWL));
        g.NamespaceMap.AddNamespace("xsd", new Uri(XmlSpecsHelper.NamespaceXmlSchema));
    }
}