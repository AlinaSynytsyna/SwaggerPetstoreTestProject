using System.Text;

namespace SwaggerPetstoreTestProject.Helpers
{
    internal class HttpRequestHelper
    {
        private static HttpClient? httpClient;

        internal HttpRequestHelper()
        {
           httpClient = new HttpClient();
        }

        internal async Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = await httpClient!.GetAsync(url);

            return response;
        }

        internal async Task<HttpResponseMessage> PostAsync(string url, string content)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpClient!.PostAsync(url, httpContent);

            return response;
        }

        internal async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var response = await httpClient!.DeleteAsync(url);

            return response;
        }
    }
}