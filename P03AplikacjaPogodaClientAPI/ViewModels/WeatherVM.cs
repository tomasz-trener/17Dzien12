using P03AplikacjaPogodaClientAPI.Models.CityModel;
using P03AplikacjaPogodaClientAPI.Tools;
using P03AplikacjaPogodaClientAPI.ViewModels.Commands;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public ObservableCollection<CityVM> Cities { get; set; } 


		public WeatherVM()
		{
			SearchCommand = new SearchCommand(this);
			accuWeatherTool = new AccuWeatherTool();
			Cities = new ObservableCollection<CityVM>();
        }

		public SearchCommand SearchCommand { get; set; }

		public async void FindCities()
		{
            City[]? cities = await accuWeatherTool.GetLocations(city);

			Cities.Clear();
			foreach (var c in cities)
				Cities.Add(
					new CityVM()
					{
						CityName = c.LocalizedName,
						Country = c.Country.LocalizedName,
						Key = c.Key
					}
					);
			// tutaj np będzie dodwalnie się do repozytorium bazodanowego 
        }

    }
}
