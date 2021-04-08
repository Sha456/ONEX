using Hahn.ApplicationProcess.February2021.Data.Repository;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Hahn.ApplicationProcess.February2021.Domain.Models.Constants;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Hahn.ApplicationProcess.February2021.Presentation.Commands;
using Hahn.ApplicationProcess.February2021.Presentation.Mapper;
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
    public class AssetHandler : IRequestHandler<CreateAssetCommand, AssetResponse>, IRequestHandler<GetAssetQuery, AssetResponse>, 
        IRequestHandler<EditAssetCommand, AssetResponse>, IRequestHandler<DeleteAssetCommand, bool>, IRequestHandler<GetAllAssetsQuery, List<AllAssetResponse>>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly ICountryRepository _countryRepository;

        public AssetHandler(IAssetRepository assetRepository, ICountryRepository countryRepository)
        {
            _assetRepository = assetRepository;
            _countryRepository = countryRepository;
        }

        public async Task<AssetResponse> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            var newAsset = ApplicationMapper.Mapper.Map<Asset>(request);

            bool depCountryIsValid = await _countryRepository.ValidCountry(newAsset.CountryOfDepartment);
            bool depEnumIsvalid = Enum.IsDefined(typeof(DepartmentEnum), newAsset.Department);
            DateTime purchaiseDateValidation = DateTime.Now.AddYears(-1);

            if (depCountryIsValid == false || depEnumIsvalid == false || purchaiseDateValidation > newAsset.PurchaseDate) return new AssetResponse
            {
                Status = false
            };

            Asset asset = await _assetRepository.CreateAsset(newAsset);

            if (asset == null)
            {
                return new AssetResponse
                {
                    Status = false
                };
            } else
            {
                return new AssetResponse
                {
                    Status = true,
                    Asset = asset
                };
            }            
        }

        public async Task<AssetResponse> Handle(GetAssetQuery request, CancellationToken cancellationToken)
        {

            Asset asset = await _assetRepository.GetAsset(request._assetId);

            if (asset == null)
            {
                return new AssetResponse
                {
                    Status = false
                };
            }
            else
            {
                return new AssetResponse
                {
                    Status = true,
                    Asset = asset
                };
            }
        }

        public async Task<AssetResponse> Handle(EditAssetCommand request, CancellationToken cancellationToken)
        {
       
            var asset = ApplicationMapper.Mapper.Map<Asset>(request);
            if (asset == null) throw new ApplicationException($"Entity could not be mapped.");

            var updatedAsset = await _assetRepository.UpdateAsset(asset);

            if (updatedAsset == null)
            {
                return new AssetResponse
                {
                    Status = false
                };
            }
            else
            {
                return new AssetResponse
                {
                    Status = true,
                    Asset = updatedAsset
                };
            }

        }

        public async Task<bool> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = ApplicationMapper.Mapper.Map<Asset>(request);
            if (asset == null) throw new ApplicationException($"Entity could not be mapped.");

            var deletedAsset = await _assetRepository.DeleteAsset(asset);

            if (deletedAsset != false)
            {
                return true;
            }
            return false;
           
        }

        public async Task<List<AllAssetResponse>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            var allAssets = await _assetRepository.GetAllAssets();
            var allAssetResponces = ApplicationMapper.Mapper.Map<List<AllAssetResponse>>(allAssets);
            return allAssetResponces;

            //List<AllAssetResponse> allAssetResponses = new List<AllAssetResponse>();
            //AssetResponse assetResponse = null;
            //foreach (var a in allAssets)
            //{
            //    if (a == null)
            //    {
            //        assetResponse = new AssetResponse
            //        {
            //            Status = false
            //        };
            //    }
            //    else
            //    {
            //        assetResponse = new AssetResponse
            //        {
            //            Status = true,
            //            Asset = a
            //        };
            //    }

            //    allAssetResponses.Add(assetResponse);
            //}

            


            //return allAssetResponses;//
            
        }
    }
}
