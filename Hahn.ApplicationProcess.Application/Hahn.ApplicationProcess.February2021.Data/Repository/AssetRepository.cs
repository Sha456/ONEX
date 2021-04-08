using Hahn.ApplicationProcess.February2021.Data.Database;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DatabaseContext _dbContext;

        public AssetRepository(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Asset> CreateAsset(Asset asset)
        {
            await _dbContext.AddAsync(asset);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Assets.FirstOrDefaultAsync(x => x.Id == asset.Id);
        }

        public async  Task<bool> DeleteAsset(Asset asset)
        {
            _dbContext.Assets.Remove(asset);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Asset>> GetAllAssets()
        {
            return await _dbContext.Assets.ToListAsync();
        }

        public async Task<Asset> GetAsset(int assetId)
        {
            return await _dbContext.Assets.FirstOrDefaultAsync(x => x.Id == assetId);
        }


        public async Task<Asset> UpdateAsset(Asset asset)
        {
            _dbContext.Assets.Update(asset);
            await _dbContext.SaveChangesAsync();

            return await GetAsset(asset.Id);
        }
    }
}
