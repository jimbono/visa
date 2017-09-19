using Refit;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace visa.poc.api
{
    public class VisaApiClient
    {
        IVisaApi _visaApi;
        X509Certificate2 _clientCertificate;
        string _basicAuthHeader;        

        public VisaApiClient(string baseApiUrl, string certificatePath, string certificatePassword, string apiUserId, string apiPassword)
        {            
            _clientCertificate = new X509Certificate2(certificatePath, certificatePassword);
            _basicAuthHeader = getBasicAuthHeader(apiUserId, apiPassword);

            var refitSettings = new RefitSettings();            
            _visaApi = RestService.For<IVisaApi>(baseApiUrl);            


        }

        public async Task<AddTravelItineraryResponse> AddTravelItinerary (AddTravelItineraryRequest request)
        {
            var response = await _visaApi.AddTravelItinerary(request, _basicAuthHeader);
            return response;
        }

        private string getBasicAuthHeader(string userId, string password)
        {
            string authString = userId + ":" + password;
            var authStringBytes = Encoding.UTF8.GetBytes(authString);
            string authHeaderString = Convert.ToBase64String(authStringBytes);
            return "Basic " + authHeaderString;
        }


    }
}
