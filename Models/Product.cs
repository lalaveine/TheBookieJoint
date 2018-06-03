namespace TheBookieJoint.Models {

    public class Product {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Translators { get; set; }
        public string Description { get; set; }
        public string OriginalLanguage { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string PublicationYear { get; set; }
        public decimal Price { get; set; }
        
    }
}
