namespace Group4Flight.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightCode { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string CabinType { get; set; } = string.Empty;
        public double Emission { get; set; }
        public string AircraftType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AirlineId { get; set; }
        public Airline? Airline { get; set; }
    }
}
