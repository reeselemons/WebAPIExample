using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Business.HttpModels;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace WebAPIExample.Business.Helpers
{
    public class HttpRequestBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="objectToJson">Object to be converted into json</param>
        /// <returns></returns>
        public async Task<HttpResponseModel> CreatePostData<T>(HttpClient httpClient, string url, T objectToJson) where T : class
        {
            var httpResponseModel = new HttpResponseModel();

            using HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, objectToJson);
            httpClient.Dispose();

            var responseMessage = response.EnsureSuccessStatusCode();
            httpResponseModel.StatusCode = responseMessage.StatusCode;

            httpResponseModel.Data = await response.Content.ReadAsStringAsync();
            return httpResponseModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="strings">i.e. "username=MikeJackson", "firstName=mike"</param>
        /// <returns></returns>
        public async Task<HttpResponseModel> CreateGetData(HttpClient httpClient, string url, params string[]? strings)
        {
            var httpResponseModel = new HttpResponseModel();

            if (strings == null)
                strings = new string[0];

            var fullUrl = $"{url}?{string.Join("&", strings)}";
            using HttpResponseMessage response = await httpClient.GetAsync(fullUrl);
            httpClient.Dispose();

            var responseMessage = response.EnsureSuccessStatusCode();
            httpResponseModel.StatusCode = responseMessage.StatusCode;

            httpResponseModel.Data = await response.Content.ReadAsStringAsync();
            return httpResponseModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="objectToJson">Object to be converted into json</param>
        /// <returns></returns>
        public HttpResponseModel CreatePostData<T>(WebClient webClient, string url, params KeyValuePair<string, string>[] pairs) where T : class
        {
            var httpResponseModel = new HttpResponseModel();

            try
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                foreach (var pair in pairs)
                    reqparm.Add(pair.Key, pair.Value);

                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var responsebytes = webClient.UploadValues(new Uri(url), "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                httpResponseModel.StatusCode = HttpStatusCode.OK;
                httpResponseModel.Data = responsebody;
            }
            catch (Exception ex)
            {
                httpResponseModel.StatusCode = HttpStatusCode.BadRequest;
            }
            return httpResponseModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="strings">i.e. "username=MikeJackson", "firstName=mike"</param>
        /// <returns></returns>
        public HttpResponseModel CreateGetData(WebClient webClient, string url, params string[]? strings)
        {
            var httpResponseModel = new HttpResponseModel();

            try
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                var fullUrl = $"{url}?{string.Join("&", strings)}";

                string response = webClient.DownloadString(fullUrl);

                httpResponseModel.StatusCode = HttpStatusCode.OK;
                httpResponseModel.Data = response;
            }
            catch (Exception ex)
            {
                httpResponseModel.StatusCode = HttpStatusCode.BadRequest;
            }
            return httpResponseModel;
        }
    }
}
