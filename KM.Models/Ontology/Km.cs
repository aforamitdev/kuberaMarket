namespace KM.Models.Ontology;

public static class Km
{
    public const string Ns = "http://kuber.finance/ontology/";
    
    public static class  Classes
    {
        public const string StockExchange = Ns + "StockExchange";
        public const string Stock = Ns + "Company";

    }

    public static class Properties
    {
        // all observed in file
        public const string Code            = Ns + "code";
        public const string Country         = Ns + "country";
        public const string Currency        = Ns + "currency";
        public const string EstablishedYear = Ns + "establishedYear";
        public const string Website         = Ns + "website";
    }
}