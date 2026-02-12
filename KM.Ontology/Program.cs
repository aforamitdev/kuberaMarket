// See https://aka.ms/new-console-template for more information

using KM.Ontology;
using VDS.RDF;
using VDS.RDF.Writing;

var store = new TripleStore();

store.Add(Company.Create(),mergeIfExists:true);
store.Add(Exchange.Create(),mergeIfExists:true);
store.Add(RelationShip.Create(),mergeIfExists:true);

// Optional: Save all
foreach (var graph in store.Graphs)
{
    Console.WriteLine(graph.BaseUri);
    var writer=new CompressingTurtleWriter();
    var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
    var final = Path.Combine(projectRoot, $"{graph.BaseUri.Segments.Last()}.owl");
    Console.WriteLine(final);
    writer.Save(graph,final);
}


