﻿using Newtonsoft.Json;
using P01AplikacjaPogodaClientAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P01AplikacjaPogodaClientAPI.Tools
{
    public class AccuWeatherTool
    {

        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        private const string api_key = "xbMfRqmiG26b3hGfUBtmiXn5nthLGIdU";

        /// <summary>
        /// Downloads locations based on locatin name 
        /// </summary>
        /// <param name="locationName"></param>
        /// <returns>Returns array of Cities. Possible null</returns>
        public async Task<City[]?> GetLocations(string locationName)
        {
            string url = base_url + "/" + string.Format(autocomplete_endpoint,api_key, locationName, "pl");

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                City[]? cities= JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }



    }
}
