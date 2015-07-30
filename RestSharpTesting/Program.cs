using System;
using System.Collections.Generic;
using RestSharp;

namespace RestSharpTesting
{
    class Program
    {
        private const string Url = "http://localhost/restsharp.webservice/api/";
        private static WebApiCaller _webApiCaller;

        static Program()
        {
            _webApiCaller = new WebApiCaller(Url);
        }

        static void Main(string[] args)
        {
            TestControllerCaller();
        }

        static void WebApiCaller()
        {
            const string controller = "test";

            var result1 = _webApiCaller.Get(controller, "get");
            var result2 = _webApiCaller.Get<IList<string>>(controller, "getlist");
            var result3 = _webApiCaller.Get<string>(controller, "get", new Dictionary<string, object> { { "index", 1 } });
            var result4 = _webApiCaller.Post<IList<string>, IList<string>>(controller, "setList", new List<string> { "Brian Korzynski", "Jennie Booth", "Ondrej Balas" });
        }

        static void TestControllerCaller()
        {
            var caller = new TestControllerCaller(_webApiCaller);

            var result1 = caller.Get();
            var result2 = caller.GetList();
            var result3 = caller.Get(1);
            var result4 = caller.SetList(new List<string> { "Brian Korzynski", "YM", "Ondrej Balas" });
        }
    }
}
