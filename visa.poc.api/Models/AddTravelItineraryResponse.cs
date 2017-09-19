using System.Collections.Generic;

public class TravelItinerary
{
    public string partnerBid { get; set; }
    public string travelItineraryId { get; set; }
    public string userId { get; set; }
    public List<PrimaryAccountNumber> primaryAccountNumbers { get; set; }
    public List<Destination> destinations { get; set; }
    public string departureDate { get; set; }
    public string returnDate { get; set; }
    public string lastUpdatedBy { get; set; }
    public string lastUpdateTime { get; set; }
}

public class AddTravelItineraryResponse
{
    public TravelItinerary travelItinerary { get; set; }
    public string responseCode { get; set; }
    public string responseMessage { get; set; }
}

public class RootObject
{
    public AddTravelItineraryResponse addTravelItineraryResponse { get; set; }
}