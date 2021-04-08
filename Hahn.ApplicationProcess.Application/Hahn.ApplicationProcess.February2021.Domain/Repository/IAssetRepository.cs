using Hahn.ApplicationProcess.February2021.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public interface IAssetRepository
    {
        Task<Asset> GetAsset(int assetId);
        Task<Asset> CreateAsset(Asset asset);
        Task<Asset> UpdateAsset(Asset asset);
        Task<bool> DeleteAsset(Asset asset);
        Task<List<Asset>> GetAllAssets();




    }
}