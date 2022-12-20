using P03AplikacjaPogodaClientAPI.Models.CityModel;
using P03AplikacjaPogodaClientAPI.Tools;
using P03AplikacjaPogodaClientAPI.ViewModels.Commands;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels
{
    public class WeatherVM
    {
		private string city = "warszawa";
		AccuWeatherTool accuWeatherTool;

        public string City
		{
			get { return city; }
			set { city = value; }
		}

		public WeatherVM()
		{
			SearchCommand = new SearchCommand(this);
			accuWeatherTool = new AccuWeatherTool();

        }

		public SearchCommand SearchCommand { get; set; }

		public async void FindCities()
		{
            City[]? cities = await accuWeatherTool.GetLocations(city);

        }

    }
}
