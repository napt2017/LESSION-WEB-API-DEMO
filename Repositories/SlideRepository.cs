using LESSION_WEB_API_DEMO.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace LESSION_WEB_API_DEMO.Repositories
{
    public interface ISlideRepository
    {
        List<SlideInfo> GetAll();
        SlideInfo Get(string id);
    }

    public class SlideRepository : ISlideRepository
    {
        private readonly ExternalApiInfo _externalApiInfo;
        private readonly RestClient _restClient;

        public SlideRepository(ExternalApiInfo externalApiInfo)
        {
            _externalApiInfo = externalApiInfo;
            _restClient = new RestClient(externalApiInfo.EndPoint);
        }

        public SlideInfo Get(string id)
        {
            var getRequestFollowId = new RestRequest($"/{id}", Method.GET);
            // $"/{id}" --> when id = 1 ==> /1
            // $"/{id}  --> when id = 2 ==> /2
            var response = _restClient.Execute(getRequestFollowId); 
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                var content = response.Content;
                return JsonConvert.DeserializeObject<SlideInfo>(content);
            }
            return null;
        }

        public List<SlideInfo> GetAll()
        {
            var getRequest = new RestRequest(Method.GET);
            var response = _restClient.Execute(getRequest);
            var responseContent = response.Content;
            var slideInfo = JsonConvert.DeserializeObject<List<SlideInfo>>(responseContent);
            return slideInfo;
        }
    }
}