using System.Collections.Generic;
using System.Web.Http;

namespace RestSharpTesting.WebService
{
    public class TestController : ApiController
    {
        //http://www.codeproject.com/Articles/615805/Creating-a-Clean-Minimal-Footprint-ASP-NET-WebAPI
        public string Get()
        {
            return "Service Worked";
        }

        public string Get([FromUri]int index)
        {
            var list = new List<string>
            {
                "Brian Korzynski",
                "YM",
                "Ondrej Balas"
            };

            return list[index];
        }

        public IList<string> GetList()
        {
            return new List<string>
            {
                "Brian Korzynski",
                "YM",
                "Ondrej Balas"
            };
        }

        [HttpPost]
        public IList<string> SetList([FromBody] IList<string> list)
        {
            list.RemoveAt(2);

            return list;
        }
    }
}
