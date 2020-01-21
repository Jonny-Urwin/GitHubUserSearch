using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubUserSearch.Common
{
    /// <summary>
    /// Makes a call to the api  
    /// </summary>
    public class ApiHelper : IApiHelper
    {
        public T GetGitHubApiData<T>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                Task<string> response = httpClient.GetStringAsync(url);

                return JsonConvert.DeserializeObject<T>(response.Result);
            }
        }

    }

    public interface IApiHelper
    {
        T GetGitHubApiData<T>(string url);
    }
}
