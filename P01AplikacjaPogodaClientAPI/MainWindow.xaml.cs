using P01AplikacjaPogodaClientAPI.Models.CityModel;
using P01AplikacjaPogodaClientAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P01AplikacjaPogodaClientAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherTool awt;
        public MainWindow()
        {
            InitializeComponent();
            awt = new AccuWeatherTool();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            City[]? cities = await awt.GetLocations(txtCity.Text);
          //  lbData.Items.Clear();
            if (cities != null)
                lbData.ItemsSource = cities;
                //foreach (var c in cities)
                //    lbData.Items.Add(c.LocalizedName);
                 
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Zadanie: 
            // Dodaj do AccuWeatherTool metodę, która na podstawie idMiasta zwróci aktualna temperture 
            // dla danego miasta
            // i wyświetli tę temperature w odpowiedniej lablece 

            // sprawdzmy, który element jest zaznaczony 
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity == null) //||)
                return;


            var weather = await awt.GetCurrentConditions(selectedCity.Key);

            if (weather != null)
            {
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);
            }
            else
                MessageBox.Show("Nie udało się pobrać temperatury dla wybranego miasta",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                       
        }
    }
}
