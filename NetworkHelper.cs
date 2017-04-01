﻿using System;
using System.Threading.Tasks;

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
    }
}
