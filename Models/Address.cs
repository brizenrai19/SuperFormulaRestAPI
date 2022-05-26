namespace SuperFormulaRestAPI.Models
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string AddressToString()
        {
            if (string.IsNullOrEmpty(AddressLine2))
                return AddressLine1 + " " + AddressLine2 + ", " + City + ", " + State + " " + Zip;
            return AddressLine1 + ", " + City + ", " + State + " " + Zip;
        }
    }
}
