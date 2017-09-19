using Refit;
using System;
using System.Threading.Tasks;

namespace visa.poc.api
{    
    public interface IVisaApi
    {
        [Post("/travelnotificationservice/v1/travelnotification/itinerary")]
        Task<AddTravelItineraryResponse> AddTravelItinerary(AddTravelItineraryRequest request, [Header("Authorization")] string authorization);
    }


}
