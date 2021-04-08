using Hahn.ApplicationProcess.February2021.Domain.Models.Models;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Hahn.ApplicationProcess.February2021.Presentation.Queries;
using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Presentation.Handlers
{
    public class CountryHandler : IRequestHandler<GetCountriesQuery, IList<CountryResponse>>
    {
        private readonly ICountryRepository _countryRepository;

        public CountryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IList<CountryResponse>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            IList<CountryModel> countryList = await _countryRepository.GetCountries();
            IList<CountryResponse> countryResponseList = new List<CountryResponse>();
            foreach (var country in countryList)
            {
                CountryResponse countryResponse = new CountryResponse
                {
                    CountryName = country.Name,
                    CountryCode = country.Alpha3Code
                };
                countryResponseList.Add(countryResponse);
            }

            return countryResponseList;

        }
    }
}
