using System;
using System.Collections.Generic;
using RestSharp;

namespace RestSharpTesting
{
    public class WebApiCaller
    {
        private readonly DataFormat _dataFormat;
        private readonly RestClient _client;

        public WebApiCaller(string apiUrl, DataFormat dataFormat = DataFormat.Json)
        {
            _dataFormat = dataFormat;
            _client = new RestClient { BaseUrl = new Uri(apiUrl) };
        }

        //Get
        //  Have 1 Parameter

        //Post
        //  Have 1 Parameter

        //PUT

        //DELETE

        private RestRequest CreateBaseRequest(string controller, string action, Method method)
        {
            return new RestRequest(string.Format("{0}/{1}", controller, action), method)
            {
                RequestFormat = _dataFormat
            };
        }

        public string Get(string controller, string action)
        {
            return this.Get<string>(controller, action);
        }

        public T Get<T>(string controller, string action)
        {
            var request = CreateBaseRequest(controller, action, Method.GET);

            return _client.Execute(request).Content.FromJson<T>();
        }

        public string Get(string controller, string action, IDictionary<string, object> queryStringParameters)
        {
            return this.Get<string>(controller, action, queryStringParameters);
        }

        public T Get<T>(string controller, string action, IDictionary<string, object> queryStringParameters)
        {
            var request = CreateBaseRequest(controller, action, Method.GET);

            foreach (var queryStringParameter in queryStringParameters)
            {
                request.AddParameter(queryStringParameter.Key, queryStringParameter.Value, ParameterType.QueryString);
            }

            return _client.Execute(request).Content.FromJson<T>();
        }

        public string Post(string controller, string action, string body)
        {
            return this.Post<string, string>(controller, action, body);
        }

        public string Post<TBody>(string controller, string action, TBody body)
        {
            return this.Post<TBody, string>(controller, action, body);
        }

        public TResult Post<TResult>(string controller, string action, string body)
        {
            return this.Post<string, TResult>(controller, action, body);
        }

        public TResult Post<TBody, TResult>(string controller, string action, TBody body)
        {
            var request = CreateBaseRequest(controller, action, Method.POST);

            request.AddBody(body);

            var content = _client.Execute(request).Content;
            
            return content.FromJson<TResult>();
        }

        public string Post(string controller, string action, string body, IDictionary<string, object> queryStringParameters)
        {
            return this.Post<string, string>(controller, action, body, queryStringParameters);
        }

        public string Post<TBody>(string controller, string action, TBody body, IDictionary<string, object> queryStringParameters)
        {
            return this.Post<TBody, string>(controller, action, body, queryStringParameters);
        }

        public TResult Post<TResult>(string controller, string action, string body, IDictionary<string, object> queryStringParameters)
        {
            return this.Post<string, TResult>(controller, action, body, queryStringParameters);
        }

        public TResult Post<TBody, TResult>(string controller, string action, TBody body, IDictionary<string, object> queryStringParameters)
        {
            var request = CreateBaseRequest(controller, action, Method.POST);

            request.AddBody(body);

            foreach (var queryStringParameter in queryStringParameters)
            {
                request.AddParameter(queryStringParameter.Key, queryStringParameter.Value, ParameterType.QueryString);
            }

            return _client.Execute(request).Content.FromJson<TResult>();
        }
    }
}
