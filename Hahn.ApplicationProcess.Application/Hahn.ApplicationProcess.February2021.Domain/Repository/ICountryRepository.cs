using Hahn.ApplicationProcess.February2021.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public interface ICountryRepository
    {
        Task<List<CountryModel>> GetCountries();
        Task<bool> ValidCountry(string countryCode);


    }
}
