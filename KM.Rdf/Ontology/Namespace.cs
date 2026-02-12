namespace KM.Rdf.Ontology;
using VDS.RDF;

public static class KmNs
{
    public static readonly Uri Base = new("http://kuber.finance/ontology/");

    public static readonly Uri Rdf  = UriFactory.Root.Create(NamespaceMapper.RDF);
    public static readonly Uri Rdfs = UriFactory.Root.Create(NamespaceMapper.RDFS);
    public static readonly Uri Owl  = UriFactory.Root.Create(NamespaceMapper.OWL);
    public static readonly Uri Xsd  = UriFactory.Root.Create(NamespaceMapper.XMLSCHEMA);
}