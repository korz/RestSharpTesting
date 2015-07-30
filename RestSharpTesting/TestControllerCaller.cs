using System.Collections.Generic;
using RestSharp;

namespace RestSharpTesting
{
    public class TestControllerCaller
    {
        private const string Controller = "Test";
        private readonly WebApiCaller _caller;

        public TestControllerCaller(string apiUrl, DataFormat dataFormat = DataFormat.Json)
        {
            _caller = new WebApiCaller(apiUrl, dataFormat);
        }

        public TestControllerCaller(WebApiCaller webApiCaller)
        {
            _caller = webApiCaller;
        }

        public string Get()
        {
            return _caller.Get(Controller, "Get");
        }

        public string Get(int index)
        {
            return _caller.Get<string>(Controller, "Get", new Dictionary<string, object> { { "Index", 1 } });
        }

        public IList<string> GetList()
        {
            return _caller.Get<IList<string>>(Controller, "GetList");
        }

        public IList<string> SetList(IList<string> list)
        {
            return _caller.Post<IList<string>, IList<string>>(Controller, "SetList", list);
        }
    }
}
