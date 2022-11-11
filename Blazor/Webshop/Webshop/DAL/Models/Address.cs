namespace Webshop.DAL.Models
{

    public partial class Address
    {
        public Guid Id { get; set; }
        public long Status { get; set; }
        public long Darstatus { get; set; }
        public string Vejkode { get; set; }
        public string Vejnavn { get; set; }
        public string Adresseringsvejnavn { get; set; }
        public string Husnr { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public string Supplerendebynavn { get; set; }
        public string Postnr { get; set; }
        public string Postnrnavn { get; set; }
        public string Stormodtagerpostnr { get; set; }
        public string Stormodtagerpostnrnavn { get; set; }
        public string Kommunekode { get; set; }
        public Guid Adgangsadresseid { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Uri Href { get; set; }
        public string Betegnelse { get; set; }
    }
}
