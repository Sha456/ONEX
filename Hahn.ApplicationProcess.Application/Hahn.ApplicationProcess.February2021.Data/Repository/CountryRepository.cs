using Hahn.ApplicationProcess.February2021.Domain.Models.Models;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {

        public CountryRepository()
        {
          
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("https://restcountries.eu/rest/v2/all");
                using HttpContent content = response.Content;
                string contentString = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CountryModel>>(contentString);


            }
        }

        public async Task<bool> ValidCountry(string countryCode)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("https://restcountries.eu/rest/v2/alpha/" +countryCode);
                using HttpContent content = response.Content;
                string contentString = await content.ReadAsStringAsync();
                CountryModel countryModel = JsonConvert.DeserializeObject<CountryModel>(contentString);


                return countryModel.Name != null ;


            }
        }
    }
}
