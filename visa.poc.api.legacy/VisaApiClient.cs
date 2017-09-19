using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace visa.poc.api
{
    public class VisaApiClient
    {        
        X509Certificate2 _clientCertificate;
        string _basicAuthHeader;        

        public VisaApiClient(string baseApiUrl, string certificatePath, string certificatePassword, string apiUserId, string apiPassword)
        {            
            _clientCertificate = new X509Certificate2(certificatePath, certificatePassword);
            _basicAuthHeader = getBasicAuthHeader(apiUserId, apiPassword);
            


        }

        public AddTravelItineraryResponse AddTravelItinerary (AddTravelItineraryRequest request)
        {

            //HttpWebRequest webRequest = WebRequest.Create(baseApiUrl) as HttpWebRequest;

            //var response = await _visaApi.AddTravelItinerary(request, _basicAuthHeader);
            return null;
        }

        private string getBasicAuthHeader(string userId, string password)
        {
            string authString = userId + ":" + password;
            var authStringBytes = Encoding.UTF8.GetBytes(authString);
            string authHeaderString = Convert.ToBase64String(authStringBytes);
            return "Basic " + authHeaderString;
        }

        private void LogRequest(string url, string requestBody)
        {
            Debug.WriteLine(url);
            Debug.WriteLine(requestBody);
        }

        private void LogResponse(string info, HttpWebResponse response)
        {
            string responseBody;
            Debug.WriteLine(info);
            Debug.WriteLine("Response Status: \n" + response.StatusCode);
            Debug.WriteLine("Response Headers: \n" + response.Headers.ToString());

            using (var reader = new StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
            {
                responseBody = reader.ReadToEnd();
            }

            Debug.WriteLine("Response Body: \n" + responseBody);
        }
    }
}
