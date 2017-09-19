using System.Collections.Generic;

public class Destination
{
    public string state { get; set; }
    public string country { get; set; }
}

public class PrimaryAccountNumber
{
    public string cardAccountNumber { get; set; }
}

public class AddTravelItinerary
{
    public string returnDate { get; set; }
    public string departureDate { get; set; }
    public List<Destination> destinations { get; set; }
    public List<PrimaryAccountNumber> primaryAccountNumbers { get; set; }
    public string userId { get; set; }
    public string partnerBid { get; set; }
}

public class AddTravelItineraryRequest
{
    public AddTravelItinerary addTravelItinerary { get; set; }
}