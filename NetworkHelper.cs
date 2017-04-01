using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2FarshStreamHelper
{
    static class NetworkHelper
    {
        class RequestFailedException : Exception
        {
        }

        public static async Task<T> FetchAsync<T>(string requestUri) where T : new()
        {
            try
            {
                var strData = await Program.httpClient.GetStringAsync(requestUri);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strData);
            }
            catch (Exception e)
            {
                // TODO
                throw;
            }
        }

        //public static void requestOnce<T>(Control caller, RestClient client, RestRequest request,
        //    ref RestRequestAsyncHandle handle, Action<T> callback) where T : new()
        //{
        //    handle?.Abort();
        //    handle = client.ExecuteAsync<T>(request,
        //        response =>
        //        {
        //            if (response.ResponseStatus == ResponseStatus.Completed)
        //            {
        //                caller.BeginInvoke(new MethodInvoker(() =>
        //                {
        //                    callback(response.Data);
        //                }));
        //            }
        //        });
        //}

        /*public static void requestUntilSuccess<T>(Control caller, RestClient client, RestRequest request,
            ref RestRequestAsyncHandle handle, Action<T> callback) where T : new()
        {
            handle?.Abort();
            handle = client.ExecuteAsync<T>(request,
                response =>
                {
                    requestUntilSuccess<T>(caller, client, request, ref handle, callback);
                });
        }*/
    }
}
