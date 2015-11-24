using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Data;
using System.Runtime.Serialization;
using RestSharp.Serializers;
using RestSharp.Deserializers;

namespace UI.Helpers
{
    // Wrapper around the RestSharp library adjusted to using SMA WCF Service
    // 1. Provide the service name (f.x. UserService.svc) as a string to constructor
    // 2. Call method to make a HTTP request, passing in the endpoint (f.x. "user/32/") and other relevant information depending on the HTTP verb.

    public class SMARestClient
    {
        private string xmlns_base = "http://schemas.datacontract.org/2004/07/";
        private const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss";
        private RestClient client;
        private RestRequest req;
        private string endpoint;

        public SMARestClient(string svc)
        {
            client = new RestClient("http://localhost:37550/" + svc);

        }

        public T Get<T>(string endpoint) where T : new()
        {
            var req = new RestRequest(endpoint, Method.GET);
            req.RequestFormat = DataFormat.Xml;
            var response = client.Execute<T>(req);

            if (response.Data == null) throw new Exception($"Get request on endpoint {endpoint} failed.");
            return response.Data;
        }

        public T Post<T>(string endpoint, T model) where T : new()
        {
            var req = new RestRequest(endpoint, Method.POST);
            req.RequestFormat = DataFormat.Xml;
            req.XmlSerializer = new XmlSerializer() { DateFormat = DATE_FORMAT };
            req.DateFormat = DATE_FORMAT;
            xmlns_base = xmlns_base + typeof(T).Namespace;
            string xmlns = string.Concat(xmlns_base, typeof(T).Namespace);
            req.AddBody(model, xmlns);
            var response = client.Execute<T>(req);

            if (response.Data == null) throw new Exception($"Post request on endpoint {endpoint} failed.");
            return response.Data;
        }

        public V Post<T,V>(string endpoint, T model) 
            where T : new() 
            where V : new()
        {
            var req = new RestRequest(endpoint, Method.POST);
            req.RequestFormat = DataFormat.Xml;
            req.XmlSerializer = new XmlSerializer() { DateFormat = DATE_FORMAT };
            req.DateFormat = DATE_FORMAT;
            string xmlns = string.Concat(xmlns_base, typeof(T).Namespace);
            req.AddBody(model, xmlns);
            var response = client.Execute(req);

            V objResponse = new XmlDeserializer().Deserialize<V>(response);
            if (objResponse == null) throw new Exception($"Post request on endpoint {endpoint} failed.");
            return objResponse;
            
        }

        public T Put<T>(string endpoint, T model) where T : new()
        {
            var req = new RestRequest(endpoint, Method.PUT);
            req.RequestFormat = DataFormat.Xml;
            //req.XmlSerializer = new DataContractSerializer(typeof(T));
            req.AddBody(model, xmlns_base);
            var response = client.Execute<T>(req);

            if (response.Data == null) throw new Exception($"Put request on endpoint {endpoint} failed.");
            return response.Data;
        }

        public void Delete(string endpoint, int id)
        {
            var req = new RestRequest(endpoint + id.ToString(), Method.DELETE);
            req.RequestFormat = DataFormat.Xml;
            var response = client.Execute(req);
            if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception($"Delete request on endpoint {endpoint} failed.");
        }
        


    }
}