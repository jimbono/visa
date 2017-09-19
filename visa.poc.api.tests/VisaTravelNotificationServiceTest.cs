using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace visa.poc.api.tests
{
    [TestClass]
    public class VisaTravelNotificationServiceTest
    {
        private VisaApiClient _visaApiClient;

        public VisaTravelNotificationServiceTest()
        {
            var visaApiUrl = ConfigurationSettings.AppSettings["visaUrl"];
            var certPath = ConfigurationSettings.AppSettings["cert"];
            var certPassword = ConfigurationSettings.AppSettings["certPassword"];
            var apiUserId = ConfigurationSettings.AppSettings["userId"];
            var apiPassword = ConfigurationSettings.AppSettings["password"];

            _visaApiClient = new VisaApiClient(visaApiUrl, certPath, certPassword, apiUserId, apiPassword);
        }

        [TestMethod]
        public async Task AddItineraryTest()
        {

            var request = createItineraryRequest();
            var response = await _visaApiClient.AddTravelItinerary(request);
            Assert.AreEqual(200, response.responseCode);
        }


        private AddTravelItineraryRequest createItineraryRequest()
        {
            var addTravelItineraryRequest = new AddTravelItineraryRequest();

            var addTravelItinerary = new AddTravelItinerary();

            addTravelItinerary.departureDate = new DateTime(2017, 9, 18).ToString("yyyy-MM-dd");
            addTravelItinerary.returnDate = new DateTime(2017, 9, 28).ToString("yyyy-MM-dd");

            var destinations = new System.Collections.Generic.List<Destination>();
            var destination = new Destination();
            destination.country = "840";
            destination.state = "CA";
            destinations.Add(destination);
            addTravelItinerary.destinations = destinations;


            var primaryAccountNumbers = new System.Collections.Generic.List<PrimaryAccountNumber>();
            var primaryAccountNumber = new PrimaryAccountNumber();
            primaryAccountNumber.cardAccountNumber = "4645191800301234";

            primaryAccountNumbers.Add(primaryAccountNumber);

            addTravelItinerary.primaryAccountNumbers = primaryAccountNumbers;

            addTravelItinerary.partnerBid = "12345678";
            addTravelItinerary.userId = "MohanKumar";

            addTravelItineraryRequest.addTravelItinerary = addTravelItinerary;

            return addTravelItineraryRequest;
        }
    }
}
